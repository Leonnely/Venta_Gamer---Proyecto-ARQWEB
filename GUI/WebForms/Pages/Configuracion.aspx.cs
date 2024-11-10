using BE;
using SECURITY;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class Configuracion : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // Llama al método ConfigurarNavbarEIdioma de la MasterPage
            if (this.Master is MasterPage masterPage)
            {
                masterPage.ConfigurarNavbarEIdioma();
            }

            LabelUser.Text = "Usuario: " + Session["user"];
            LabelIdioma.Text = "Idioma: " + Session["language"];
          

            
        }
       
    }
}