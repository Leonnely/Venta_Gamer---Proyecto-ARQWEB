using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.WebForms.Models
{
    public static class RoleBasedNavbar
    {
        // Definir el navbar basado en roles
        public static Dictionary<string, List<NavbarItem>> RoleNavItems = new Dictionary<string, List<NavbarItem>>()
        {
            { "Admin", new List<NavbarItem>
            {
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "~/WebForms/Pages/home.aspx" },
                new NavbarItem { Name = "Bitacora", TextKey = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                new NavbarItem { Name = "Gestion de perfiles", TextKey = "Gestion de perfiles", Url = "~/WebForms/Pages/ABMperfiles.aspx" }
                new NavbarItem { Name = "Gestion de productos", TextKey = "Gestion de productos", Url = "~/WebForms/Pages/Productos.aspx" },
                new NavbarItem { Name = "Configuracion", TextKey = "Configuracion", Url = "~/WebForms/Pages/Configuracion.aspx" }
            }
        },
        { "User", new List<NavbarItem>
            {
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "~/WebForms/Pages/home.aspx" },
                new NavbarItem { Name = "Carrito", TextKey = "Carrito", Url = "~/WebForms/Pages/carrito.aspx" },
                new NavbarItem { Name = "Gestion de perfiles", TextKey = "Gestion de perfiles", Url = "~/WebForms/Pages/ABMperfiles.aspx" }
                new NavbarItem { Name = "Configuracion", TextKey = "Configuracion", Url = "~/WebForms/Pages/Configuracion.aspx" }
            }
        },
        { "WebMaster", new List<NavbarItem>
            {
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "~/WebForms/Pages/home.aspx" },
                new NavbarItem { Name = "Bitacora", TextKey = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                new NavbarItem { Name = "Gestion DB", TextKey = "Gestion DB", Url = "~/WebForms/Pages/backup.aspx" },
                new NavbarItem { Name = "Configuracion", TextKey = "Configuracion", Url = "~/WebForms/Pages/Configuracion.aspx" }
            }
        }
        };
    }
}