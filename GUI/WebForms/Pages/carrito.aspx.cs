using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using BE;
using SERVICES;

namespace GUI.WebForms.Pages
{
    public partial class carrito : System.Web.UI.Page, IIdiomaObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener referencia a la página maestra
                var masterPage = this.Master as MasterPage;

                if (masterPage != null)
                {
                    masterPage.ConfigurarNavbarEIdioma(); // Método centralizado para configurar el navbar
                }

                if (!IsPostBack)
                {
                    // Suscribir la página al IdiomaSubject para que observe los cambios de idioma
                    var idiomaSubject = IdiomaSubject.Instance;
                    idiomaSubject.Attach(this);

                    CargarCarrito();
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
            }
        }

        public void UpdateIdioma(Dictionary<string, string> textosActuales)
        {
            // Iterar sobre los items del Repeater y actualizar los textos
            foreach (RepeaterItem item in rptCarrito.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Button btnActualizar = (Button)item.FindControl("btnActualizar");
                    Button btnEliminar = (Button)item.FindControl("btnEliminar");

                    // Actualizar el texto de los botones con los valores traducidos
                    if (btnActualizar != null)
                    {
                        btnActualizar.Text = IdiomaSubject.GetTexto("ActualizarCarrito");
                    }

                    if (btnEliminar != null)
                    {
                        btnEliminar.Text = IdiomaSubject.GetTexto("EliminarCarrito");
                    }
                }
            }
        }

        private void CargarCarrito()
        {
            // Obtener el carrito de la sesión
            Dictionary<string, int> carrito = Session["Carrito"] != null
                ? (Dictionary<string, int>)Session["Carrito"]
                : new Dictionary<string, int>();

            // Llamada al servicio para obtener los productos con sus precios
            ProductsService productService = new ProductsService();
            List<BE_Productos> productosDisponibles = productService.GetProducts();

            // Crear lista de productos en el carrito con sus precios y calcular el total
            decimal totalCompra = 0;

            // Crear lista de productos en el carrito con sus precios
            var productosCarrito = carrito.Select(item =>
            {
                // Buscar el producto en la lista obtenida del servicio
                var producto = productosDisponibles.FirstOrDefault(p => p.Title == item.Key);

                // Asignar el precio si el producto existe; de lo contrario, usar 0 como valor por defecto
                decimal precio = producto != null ? producto.Price : 0;
                decimal totalProducto = precio * item.Value;

                totalCompra += totalProducto;

                return new
                {
                    Producto = item.Key,
                    Cantidad = item.Value,
                    Precio = precio,
                    Total = precio * item.Value
                };
            }).ToList();

            // Asignar la lista de productos al Repeater
            rptCarrito.DataSource = productosCarrito;
            rptCarrito.DataBind();

            // Mostrar el total de la compra en la etiqueta
            lblTotalCompra.Text = $"Total: ${totalCompra}";

            // Mostrar el botón de confirmación solo si el total es mayor a 0
            btnConfirmarCompra.Visible = totalCompra > 0;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Button btnActualizar = (Button)sender;
            string producto = btnActualizar.CommandArgument;

            // Obtener la fila en la que se hizo clic
            RepeaterItem item = (RepeaterItem)btnActualizar.NamingContainer;
            TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");

            int nuevaCantidad;
            if (int.TryParse(txtCantidad.Text, out nuevaCantidad) && nuevaCantidad > 0)
            {
                // Obtener el carrito de la sesión
                Dictionary<string, int> carrito = (Dictionary<string, int>)Session["Carrito"];

                // Actualizar la cantidad del producto
                carrito[producto] = nuevaCantidad;

                // Guardar el carrito actualizado en la sesión
                Session["Carrito"] = carrito;

                // Recargar el carrito
                CargarCarrito();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Cantidad inválida.');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string producto = btnEliminar.CommandArgument;

            // Obtener el carrito de la sesión
            Dictionary<string, int> carrito = (Dictionary<string, int>)Session["Carrito"];

            // Eliminar el producto del carrito
            carrito.Remove(producto);

            // Actualizar la sesión
            Session["Carrito"] = carrito;

            // Recargar el carrito
            CargarCarrito();
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            // Obtener el carrito y el total para guardarlo en la sesión
            Dictionary<string, int> carrito = (Dictionary<string, int>)Session["Carrito"];
            ProductsService productService = new ProductsService();
            List<BE_Productos> productosDisponibles = productService.GetProducts();

            // Generar la lista de detalles de la compra y calcular el total
            List<BE_DetalleCompra> detallesCompra = carrito.Select(item =>
            {
                var producto = productosDisponibles.FirstOrDefault(p => p.Title == item.Key);
                decimal precio = producto != null ? producto.Price : 0;
                decimal total = precio * item.Value;

                return new BE_DetalleCompra
                {
                    Producto = item.Key,
                    Cantidad = item.Value,
                    Precio = precio,
                    Total = total
                };
            }).ToList();

            decimal totalCompra = detallesCompra.Sum(d => d.Total);

            // Guardar detalles de la compra en el XML
            GuardarDetalleCompraXML(totalCompra, detallesCompra);

            // Guardar los detalles en la sesión para usarlos en DetalleCompra.aspx
            Session["DetallesCompra"] = detallesCompra;

            // Redirigir a DetalleCompra.aspx para mostrar el resumen
            Response.Redirect("DetalleCompra.aspx");
        }

        private void GuardarDetalleCompraXML(decimal totalCompra, List<BE_DetalleCompra> detallesCompra)
        {
            // Crear o actualizar el archivo XML
            string filePath = Server.MapPath("../../App_Data/Ventas.xml");
            XDocument doc;

            try
            {
                if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
                {
                    doc = XDocument.Load(filePath);
                }
                else
                {
                    doc = new XDocument(new XElement("Ventas"));
                }
            }
            catch (XmlException)
            {
                doc = new XDocument(new XElement("Ventas"));
            }

            XElement venta = new XElement("Venta",
                new XElement("UsuarioID", Session["id"]),
                new XElement("Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("TotalCompra", totalCompra)
            );

            foreach (var detalle in detallesCompra)
            {
                venta.Add(new XElement("Item",
                    new XElement("Producto", detalle.Producto),
                    new XElement("Cantidad", detalle.Cantidad),
                    new XElement("Precio", detalle.Precio),
                    new XElement("Total", detalle.Total)
                ));
            }

            doc.Element("Ventas").Add(venta);
            doc.Save(filePath);
        }   
    }
}
