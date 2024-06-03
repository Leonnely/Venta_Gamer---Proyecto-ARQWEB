using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bienvenido " + Session["user"];
            int role = (int)Session["role"];
            
            switch (role)
            {
                case 0:
                    Label2.Text= "ROL: Administrador";
                    break;
                case 1:
                    Label2.Text = "ROL: Usuario";
                    break;
                       
            }

            
        }
    }
}