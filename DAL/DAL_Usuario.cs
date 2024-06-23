using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        

        public int role;

        //INICIO DE SESION
        public bool Login(string username, string password)
        {
            BE_Usuario user = new BE_Usuario(username, password,0);
            foreach (var usuario in zDatos.users)
            {
                if (usuario.Username == username && usuario.Password == password)
                {
                    user.Role= usuario.Role;
                    role=user.Role;
                    return true;
                }
            }
            return false;

        }


    }
}
