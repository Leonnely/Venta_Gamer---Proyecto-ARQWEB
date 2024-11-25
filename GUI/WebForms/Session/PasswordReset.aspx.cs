using SECURITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Session
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar navbar y idioma
                if (this.Master is GUI.WebForms.Pages.MasterPage masterPage)
                {
                    masterPage.ConfigurarNavbarEIdioma();
                }
            }

            TextBoxNewPass.Enabled = false;
            ButtonEnviar.Enabled = false;
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            LoginManager login = new LoginManager();
            login.updatePassword(TextBoxUsername.Text, TextBoxNewPass.Text);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBoxRespuesta.Text == "Sabato")
            {
                TextBoxNewPass.Enabled = true;
                ButtonEnviar.Enabled = true;
            }
        }
    }
}