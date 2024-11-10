using BE;
using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class Productos : System.Web.UI.Page, IIdiomaObserver { 
        private BLL_Productos bllProductos = new BLL_Productos();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Llama al método ConfigurarNavbarEIdioma de la MasterPage
            if (this.Master is MasterPage masterPage)
            {
                masterPage.ConfigurarNavbarEIdioma();
            }

            // Añadir categorías al DropDownList
            if (!IsPostBack)  // Verifica que solo se ejecute una vez al cargar la página
            {
                ddlCategory.Items.Add(new ListItem("Selecciona una categoría", "0"));
                ddlCategory.Items.Add(new ListItem("GPU", "1"));
                ddlCategory.Items.Add(new ListItem("CPU", "2"));
                ddlCategory.Items.Add(new ListItem("RAM", "3"));
                // Añadir más categorías si es necesario
            }
        }

    protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "0" || string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                lblMessage.Text = "Por favor, completa todos los campos.";
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                lblMessage.Text = "Por favor, ingresa un precio válido.";
                return;
            }


            BE_Productos productos = new BE_Productos();
            productos.Price = price;
            productos.Category= ddlCategory.SelectedItem.Text;
            productos.Title = txtTitle.Text;

            

            try
            {
                bllProductos.AddProduct(productos);
                lblMessage.Text = "Producto cargado exitosamente";
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar el producto: {ex.Message}";
            }
        }

        public void UpdateIdioma(Dictionary<string, string> textos)
        {
            throw new NotImplementedException();
        }
    }
}