﻿using System;
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
using BE;

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
                    var idiomaSubject = new SERVICES.IdiomaSubject();
                    idiomaSubject.CambiarIdiomaDesdeDB(idiomaCodigo);

                    var navbarItems = RoleBasedNavbar.RoleNavItems.ContainsKey(role)
                            ? RoleBasedNavbar.RoleNavItems[role]
                            : RoleBasedNavbar.RoleNavItems["User"];

                    GenerateNavbar(navbarItems);

                    LoadProducts();

                }
            }
            else
            {
                Response.Redirect("~/WebForms/Pages/ErrorPage.aspx");
            }
        }


        private void LoadProducts()
        {
            ProductsService service = new ProductsService();
            List<Productos> products = service.GetProducts();
            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
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
                    InnerText = SERVICES.IdiomaSubject.GetTexto(item.Name), // Obtiene el texto traducido usando el Observer
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
                Text = SERVICES.IdiomaSubject.GetTexto("CerrarSesion"), 
                CssClass = "logout-button"
            };
            logoutButton.Click += LogoutButton_Click;

            navbarRightDiv.Controls.Add(logoutButton);

            navbar.Controls.Add(navbarLeftDiv);
            navbar.Controls.Add(navbarRightDiv);


        }

        private void FillLanguageDropDown(System.Web.UI.WebControls.DropDownList dropDown)
        {
            var bllGestionIdioma = new BLL_GestionIdioma();
            var idiomas = bllGestionIdioma.ObtenerIdiomas(); 
            foreach (var idioma in idiomas)
            {
                dropDown.Items.Add(new ListItem(idioma.Nombre, idioma.Codigo));
            }

            if (Session["language"] != null)
            {
                dropDown.SelectedValue = Session["language"].ToString();
            }
            else
            {
                dropDown.SelectedValue = "es-ES"; // Idioma por defecto
            }
        }

        protected void LanguageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (System.Web.UI.WebControls.DropDownList)sender;
            string nuevoIdioma = dropDown.SelectedValue;
            int userId = (int)Session["id"];

            LoginManager loginManager = new LoginManager();

            var idiomaSubject = new SERVICES.IdiomaSubject();
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
