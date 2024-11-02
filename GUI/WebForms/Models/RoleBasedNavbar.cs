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
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "/" },
                new NavbarItem { Name = "Dashboard", TextKey = "Dashboard", Url = "/" },
                new NavbarItem { Name = "Bitacora", TextKey = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                new NavbarItem { Name = "Gestion de productos", TextKey = "Gestion de productos", Url = "/" },
                new NavbarItem { Name = "Settings", TextKey = "Settings", Url = "/" }
            }
        },
        { "User", new List<NavbarItem>
            {
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "/" },
                new NavbarItem { Name = "Carrito", TextKey = "Carrito", Url = "~/WebForms/Pages/carrito.aspx" },
                new NavbarItem { Name = "Settings", TextKey = "Settings", Url = "/" }
            }
        },
        { "WebMaster", new List<NavbarItem>
            {
                new NavbarItem { Name = "Home", TextKey = "Home", Url = "/" },
                new NavbarItem { Name = "Bitacora", TextKey = "Bitacora", Url = "~/WebForms/Pages/bitacora.aspx" },
                new NavbarItem { Name = "Gestion DB", TextKey = "Gestion DB", Url = "~/WebForms/Pages/backup.aspx" }
            }
        }
        };
    }
}