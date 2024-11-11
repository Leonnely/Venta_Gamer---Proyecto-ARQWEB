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


                ddlEditCategory.Items.Add(new ListItem("Selecciona una categoría", "0"));
                ddlEditCategory.Items.Add(new ListItem("GPU", "1"));
                ddlEditCategory.Items.Add(new ListItem("CPU", "2"));
                ddlEditCategory.Items.Add(new ListItem("RAM", "3"));
               


                LoadProducts();

                if (Session["ddlSelected"] != null)
                {
                    string selectedValue = Session["ddlSelected"].ToString();
                    if (ddlProducts.Items.FindByValue(selectedValue) != null)
                    {
                        ddlProducts.SelectedValue = selectedValue;  // Restaurar la selección
                    }
                }

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


        private void LoadProducts()
        {
            ddlProducts.Items.Clear();
            ddlProducts.Items.Add(new ListItem("Selecciona un producto", "0"));
            ddlEditProduct.Items.Clear();
            ddlEditProduct.Items.Add(new ListItem("Selecciona un producto", "0"));
            List<BE_Productos> products = bllProductos.GetProducts();

            foreach (BE_Productos product in products)
            {
                ddlProducts.Items.Add(new ListItem(product.Title, product.Id.ToString()));
                ddlEditProduct.Items.Add(new ListItem(product.Title, product.Id.ToString()));
            }

            if (Session["ddlSelected"] != null)
            {
                string selectedValue = Session["ddlSelected"].ToString();
                if (ddlProducts.Items.FindByValue(selectedValue) != null)
                {
                    ddlProducts.SelectedValue = selectedValue;  // Restaurar la selección
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddlSelected"] = ddlProducts.SelectedItem.Text;
        }


        protected void ddlEditProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productName = ddlEditProduct.SelectedItem.Text.ToString();

            if (productName!="")  // Verifica si se seleccionó un producto válido
            {
                var product = bllProductos.GetProducts().FirstOrDefault(p => p.Title == productName);
                if (product != null)
                {
                    txtEditTitle.Text = product.Title;
                    txtEditPrice.Text = product.Price.ToString();
                    ddlEditCategory.SelectedItem.Text = product.Category;  
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           
                try
                {
                string selectedProduct = Session["ddlSelected"]?.ToString();
                if (string.IsNullOrEmpty(selectedProduct))
                {
                    lblDeleteMessage.Text = "Por favor, selecciona un producto válido.";
                    return;
                }

                int productId;
               
                List<BE_Productos> products = bllProductos.GetProducts();
                foreach (BE_Productos product in products)
                {
                    if (product.Title == selectedProduct )
                    {
                        productId = product.Id;
                        bllProductos.DeleteProduct(productId);
                        lblDeleteMessage.Text = "Producto eliminado exitosamente.";
                        lblDeleteMessage.CssClass = "message success";
                        LoadProducts(); // Actualizar la lista de productos
                        break;
                    }

                }
                    
                }
                catch (Exception ex)
                {
                    lblDeleteMessage.Text = $"Error al eliminar el producto: {ex.Message}";
                }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = ddlEditProduct.SelectedItem.Text.ToString();
                if (productName != "")  // Verifica si se seleccionó un producto válido
                {
                    var product = bllProductos.GetProducts().FirstOrDefault(p => p.Title == productName);
                    int productId = product.Id;

                    if (productId == 0)
                    {
                        lblUpdateMessage.Text = "Por favor, selecciona un producto.";
                        return;
                    }

                    string title = txtEditTitle.Text;
                    decimal price;
                    if (!decimal.TryParse(txtEditPrice.Text, out price))
                    {
                        lblUpdateMessage.Text = "Por favor, ingresa un precio válido.";
                        return;
                    }

                    int category = int.Parse(ddlEditCategory.SelectedValue);
                    if (category == 0)
                    {
                        lblUpdateMessage.Text = "Por favor, selecciona una categoría.";
                        return;
                    }

                    BE_Productos productToUpdate = new BE_Productos
                    {
                        Id = productId,
                        Title = title,
                        Price = price,
                        Category = ddlEditCategory.SelectedItem.Text
                    };

                    bllProductos.UpdateProduct(productToUpdate);  // Asumimos que tienes este método en tu BLL
                    lblUpdateMessage.Text = "Producto actualizado exitosamente.";
                    lblUpdateMessage.CssClass = "message success";

                    LoadProducts();  // Recargar la lista de productos
                }
            }
            catch (Exception ex)
            {
                lblUpdateMessage.Text = $"Error al actualizar el producto: {ex.Message}";
                lblUpdateMessage.CssClass = "message error";
            }
        }

      
    }
    }
