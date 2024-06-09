using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class zDatos
    {

        
        public static List<BE_RegistroBitacora> Bitacora = new List<BE_RegistroBitacora>
        {
            new BE_RegistroBitacora("Admin", "Inicio de sesion", "Login"),
            new BE_RegistroBitacora("WebMaster", "Consulta de Bitacora", "Bitacora"),
            new BE_RegistroBitacora("Admin", "Cierre de sesion", "Login")
        };


        public static List<BE_Usuario> users = new List<BE_Usuario>
        {
                new BE_Usuario("Admin", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", 0),
                new BE_Usuario("WebMaster", "9345f46722d90fb745060f5725ae0f1b20c5ec60a25532bde04e76b9f651db60", 2),
                new BE_Usuario("user3", "user3", 1),
                new BE_Usuario("user4", "user4", 1),
                new BE_Usuario("user5", "user5", 1)
        };


    }
}
