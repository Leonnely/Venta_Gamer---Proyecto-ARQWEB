﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.WebForms.Pages
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = GetUserRole((int)Session["role"]);

            var navbarItems = RoleBasedNavbar.RoleNavItems.ContainsKey(role)
                    ? RoleBasedNavbar.RoleNavItems[role]
                    : RoleBasedNavbar.RoleNavItems["User"];

            GenerateNavbar(navbarItems);
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

            foreach (var item in navbarItems)
            {
                var link = new System.Web.UI.HtmlControls.HtmlAnchor
                {
                    InnerText = item.Name,
                    HRef = item.Url
                };
                link.Attributes["class"] = "nav-link";
                navbarLeftDiv.Controls.Add(link);
            }

            var navbarRightDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            navbarRightDiv.Attributes["class"] = "navbar--right";
            //navbarRightDiv.InnerText = "Bienvenido " + GetUserRole((int)Session["role"]);

            var logoutButton = new System.Web.UI.WebControls.Button
            {
                Text = "Cerrar sesión",
                CssClass = "logout-button"
            };
            logoutButton.Click += LogoutButton_Click;

            navbarRightDiv.Controls.Add(logoutButton);

            navbar.Controls.Add(navbarLeftDiv);
            navbar.Controls.Add(navbarRightDiv);
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
                        new NavbarItem { Name = "Dashboard", Url = "/Admin/Dashboard" },
                        new NavbarItem { Name = "User Management", Url = "/Admin/Users" },
                        new NavbarItem { Name = "Gestion de productos", Url = "/Admin/Products" },
                        new NavbarItem { Name = "Settings", Url = "/Admin/Settings" }
                    }
                },
                { "User", new List<NavbarItem>
                    {
                        new NavbarItem { Name = "Home", Url = "/" },
                        new NavbarItem { Name = "Carrito", Url = "/User/Profile" },
                        new NavbarItem { Name = "Settings", Url = "/User/Settings" }
                    }
                },
                { "WebMaster", new List<NavbarItem>
                    {
                        new NavbarItem { Name = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                        new NavbarItem { Name = "UFP", Url = "~/UFP.aspx" },
                        new NavbarItem { Name = "Encriptacion", Url = "~/Encriptacion.aspx" },
                        new NavbarItem { Name = "Backup", Url = "~/Backup.aspx" },
                        new NavbarItem { Name = "Restore", Url = "~/Restore.aspx" }
                    }
                }
            };
        }
    }
