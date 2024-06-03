using BE;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECURITY
{
    public class LoginManager
    {

        
        SessionManager sessionManager = new SessionManager();
        public int role;
        public bool login(string username, string password)
        {

            string HashedPassword= CryptoManager.HashPassword(password);
            DAL_Usuario user = new DAL_Usuario();
            bool sesion = user.Login(username, HashedPassword);
            if( sesion )
            {
                if (sessionManager.CheckSession == null)
                {
                   
                    sessionManager.CreateSession(username);
                    BE_RegistroBitacora registroBitacora = new BE_RegistroBitacora(username, "Inicio de sesion", "Login");
                    BLL_Bitacora bitacora = new BLL_Bitacora();
                    bitacora.BitacoraRegister(registroBitacora);
                    role = user.role;
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
            


        }







    }
}
