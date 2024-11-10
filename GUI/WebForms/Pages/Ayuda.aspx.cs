using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class Ayuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master is MasterPage masterPage)
            {
                masterPage.ConfigurarNavbarEIdioma();
            }
        }
    }
}