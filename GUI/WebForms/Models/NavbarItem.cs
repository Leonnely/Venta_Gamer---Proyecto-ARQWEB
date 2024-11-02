using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.WebForms.Models
{
    public class NavbarItem
    {
        public string Name { get; set; }
        public string TextKey { get; set; }  // La clave original en la base de datos
        public string Url { get; set; }
    }
}