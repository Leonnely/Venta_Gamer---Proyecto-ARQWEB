using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using SECURITY;
using SERVICES;

namespace GUI.WebForms.Pages
{
    public partial class home : System.Web.UI.Page
    {
        //prueba de rama leo
        //otra prueba
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                string role = GetUserRole((int)Session["role"]);

                if (role == "A")
                {
                    Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
                }
                else
                {
                    string idiomaCodigo = Session["language"] != null ? Session["language"].ToString() : "es-ES"; ;

                    // Cambia el idioma a través de la instancia de IdiomaSubject
                    var idiomaSubject = new Services.IdiomaSubject();
                    idiomaSubject.CambiarIdiomaDesdeDB(idiomaCodigo);

                    var navbarItems = RoleBasedNavbar.RoleNavItems.ContainsKey(role)
                            ? RoleBasedNavbar.RoleNavItems[role]
                            : RoleBasedNavbar.RoleNavItems["User"];

                    GenerateNavbar(navbarItems);
                    

                }
            }
            else
            {
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
            }
        }

        //OBTENER EL ROL DE USUARIO
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

        //GENERACION DE NAVBAR
        private void GenerateNavbar(List<NavbarItem> navbarItems)
        {
            var navbarDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            navbarDiv.Attributes["class"] = "navbar";

            var navbarLeftDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            navbarLeftDiv.Attributes["class"] = "navbar--left";
            //lean estuvo aca

            // acá itero a través de los elementos del navbar y agrego textos traducidos
            foreach (var item in navbarItems)
            {
                var link = new System.Web.UI.HtmlControls.HtmlAnchor
                {
                    InnerText = Services.IdiomaSubject.GetTexto(item.Name), // Obtiene el texto traducido usando el Observer
                    HRef = item.Url
                };
                link.Attributes["class"] = "nav-link";
                navbarLeftDiv.Controls.Add(link);
            }

            var navbarRightDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            navbarRightDiv.Attributes["class"] = "navbar--right";

            // creo el control DropDownList para seleccionar el idioma
            var languageDropDown = new System.Web.UI.WebControls.DropDownList
            {
                ID = "ddlLanguages",
                AutoPostBack = true,
                CssClass = "language-dropdown"
            };
            languageDropDown.SelectedIndexChanged += LanguageDropDown_SelectedIndexChanged; 

            FillLanguageDropDown(languageDropDown);

            navbarRightDiv.Controls.Add(languageDropDown);

            // Boton de Cerrar sesión
            var logoutButton = new System.Web.UI.WebControls.Button
            {
                Text = Services.IdiomaSubject.GetTexto("CerrarSesion"), 
                CssClass = "logout-button"
            };
            logoutButton.Click += LogoutButton_Click;

            navbarRightDiv.Controls.Add(logoutButton);

            navbar.Controls.Add(navbarLeftDiv);
            navbar.Controls.Add(navbarRightDiv);


        }

        private void FillLanguageDropDown(System.Web.UI.WebControls.DropDownList dropDown)
        {
            using (var connection = new SqlConnection(@"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();
                var command = new SqlCommand("SELECT LanguageCode, LanguageName FROM IDIOMA", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Agregar cada idioma al DropDownList
                        dropDown.Items.Add(new ListItem(reader["LanguageName"].ToString(), reader["LanguageCode"].ToString()));
                    }
                }
            }

            // Verificar si hay un idioma guardado en la sesión
            if (Session["language"] != null)
            {
                // Seleccionar el valor guardado en la sesión
                dropDown.SelectedValue = Session["language"].ToString();
            }
            else
            {
                // Establecer el valor predeterminado si no hay un idioma en la sesión
                dropDown.SelectedValue = "es-ES"; // Ajusta esto al idioma predeterminado que desees
            }
        }

        protected void LanguageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (System.Web.UI.WebControls.DropDownList)sender;
            string nuevoIdioma = dropDown.SelectedValue;
            int userId = (int)Session["id"];

            LoginManager loginManager = new LoginManager();

            var idiomaSubject = new Services.IdiomaSubject();
            idiomaSubject.CambiarIdiomaDesdeDB(nuevoIdioma);

            Session["language"] = nuevoIdioma;
            
            loginManager.updateLanguaje(userId, idiomaSubject.ObtenerIdDesdeIdioma(nuevoIdioma));

            // Recarga la página para aplicar el cambio de idioma
            Response.Redirect(Request.RawUrl);
        }


        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/WebForms/Session/login.aspx"); 
        }


    }

        public class NavbarItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public static class RoleBasedNavbar
        {
            //CREACION DE ELEMENTOS DE NAVBAR POR USUARIO
            public static Dictionary<string, List<NavbarItem>> RoleNavItems = new Dictionary<string, List<NavbarItem>>()
            {
                { "Admin", new List<NavbarItem>
                    {
                        new NavbarItem { Name = "Home", Url = "/" },
                        new NavbarItem { Name = "Dashboard", Url = "/" },
                        new NavbarItem { Name = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                        new NavbarItem { Name = "Gestion de productos", Url = "/" },
                        new NavbarItem { Name = "Settings", Url = "/" }
                    }
                },
                { "User", new List<NavbarItem>
                    {
                        new NavbarItem { Name = "Home", Url = "/" },
                        new NavbarItem { Name = "Carrito", Url = "/" },
                        new NavbarItem { Name = "Settings", Url = "/" }
                    }
                },
                { "WebMaster", new List<NavbarItem>
                    {
                        new NavbarItem { Name = "Home", Url = "/" },
                        new NavbarItem { Name = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                        //new NavbarItem { Name = "UFP", Url = "~/UFP.aspx" },
                        //new NavbarItem { Name = "Encriptacion", Url = "~/Encriptacion.aspx" },
                        new NavbarItem { Name = "Gestion DB", Url = "~/WebForms/Pages/backup.aspx" },
                        //new NavbarItem { Name = "Restore", Url = "~/Restore.aspx" }
                    }
                }
            };
        }
    }
