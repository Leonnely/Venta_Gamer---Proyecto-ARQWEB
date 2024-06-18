using SECURITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Session
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                LoginManager loginManager = new LoginManager();

                if(loginManager.login(username, password))
                {
                    Session["role"] = loginManager.role;
                    Session["user"]=  txtUsername.Text;
                    Response.Redirect("~/WebForms/Pages/home.aspx");
                }
                else
                {
                    lblMessage.Text = "Error al iniciar sesion";
                }
            }
          
        }
    }
}