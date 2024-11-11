using BE;
using SECURITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GUI.WebForms.Session
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
            }
        }
        private BLL_Perfil BLLPerfi = new BLL_Perfil();
        private List<string> roles;
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validar que no estén vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "El nombre de usuario y la contraseña son obligatorios.";
                return;
            }

            int perfil = GetUserRole(DDLrol.Text);
            

            LoginManager loginManager = new LoginManager();

            bool success = loginManager.Register(username, password, perfil);

            if (success)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Registro exitoso.";
                Response.Redirect("~/WebForms/Session/login.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error al registrar el usuario.";
            }

        }
        public int GetUserRole(string rol)
        {
            switch (rol)
            {
                //Agregar dependiendo los perfiles de la tabla perfiles
                case "Tester Perfiles":
                    return 4;
                case "Tester B":
                    return 5;
                default:
                    return 0;
            }
        }
        private void CargarRoles()
        {
            roles = BLLPerfi.ObtenerDescripcionesRoles(); // Método en BLLUsuario que obtiene las descripciones de roles
            DDLrol.DataSource = roles;
            //DDLrol.DataTextField = "Descripcion";
            //DDLrol.DataValueField = "ID";
            DDLrol.DataBind();
        }
    }
}