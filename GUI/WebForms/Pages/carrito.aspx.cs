using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            // objetos anónimos para mostrar en el Repeater
            var productosCarrito = carrito.Select(item => new
            {
                Producto = item.Key,
                Cantidad = item.Value,
                Precio = 100, //Falta ajustar en base al valor del product
                Total = 100 * item.Value // Precio * Cantidad
            }).ToList();

            // Asignar la lista de productos al Repeater
            rptCarrito.DataSource = productosCarrito;
            rptCarrito.DataBind();
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
    }
}
