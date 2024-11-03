using BE;
using GUI.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
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
                    int pageNumber = 1;
                    int pageSize = 16; 
                    LoadProducts(pageNumber,pageSize);
                   
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


        private void LoadProducts(int pageNumber = 1, int pageSize = 16)
        {
            ProductsService service = new ProductsService();
            List<Productos> products = service.GetProductsByPagination(pageNumber, pageSize);
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();

            // Calcular total de productos
            int totalProducts = service.GetTotalProductsCount();
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            // Calcular el rango de páginas a mostrar
            int startPage = Math.Max(1, pageNumber - 5);
            int endPage = Math.Min(totalPages, startPage + 9);

            if (endPage - startPage < 9)
            {
                startPage = Math.Max(1, endPage - 9);
            }

            List<int> pagesToShow = Enumerable.Range(startPage, endPage - startPage + 1).ToList();

            PaginationRepeater.DataSource = pagesToShow.Select(p => new { PageNumber = p });
            PaginationRepeater.DataBind();
        }


        protected void lnkPage_Click(object sender, EventArgs e)
        {
            LinkButton lnkButton = (LinkButton)sender;
            int pageNumber = int.Parse(lnkButton.CommandArgument);
            LoadProducts(pageNumber, 16);
            //Llamo la funcion del master xq el navbar no se muestra si cambia de pagina nose q le pasa
            MasterPage miMaster = this.Master as MasterPage; 
            if (miMaster != null)
            {
                miMaster.ConfigurarNavbarEIdioma();
            }
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
