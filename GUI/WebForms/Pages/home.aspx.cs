using BE;
using GUI.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Cargar productos solo si no es postback
                    LoadProducts();
                   
                    if (this.Master is MasterPage masterPage)
                    {
                        masterPage.ConfigurarNavbarEIdioma();
                    }
                }

            }
            catch (Exception)
            {
                // Manejar posibles errores
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
            }
        }

        private void LoadProducts()
        {
            ProductsService service = new ProductsService();
            List<Productos> products = service.GetProducts();
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/WebForms/Session/login.aspx");
            }
            else
            {
                Button btn = (Button)sender;
                string producto = btn.CommandArgument;

                Dictionary<string, int> carrito = Session["Carrito"] != null
                    ? (Dictionary<string, int>)Session["Carrito"]
                    : new Dictionary<string, int>();

                if (carrito.ContainsKey(producto))
                {
                    carrito[producto]++;
                }
                else
                {
                    carrito.Add(producto, 1);
                }

                Session["Carrito"] = carrito;

                // Falta ajustar acá para que muestre un mensaje al agregar al carrito

                Response.Redirect(Request.RawUrl);  // Esto recargará la página
            }
        }


        public string GetUserRole(int rol)
        {
            switch (rol)
            {
                case 0:
                    return "Administrador";
                case 1:
                    return "WebMaster";
                case 2:
                    return "User";
                default:
                    return "A";
            }
        }
    }
}
