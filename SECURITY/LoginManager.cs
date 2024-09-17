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
        private readonly DVManager _digitoManager;
        public LoginManager() 
        {
            _digitoManager = new DVManager();
        }

        SessionManager sessionManager = new SessionManager();
        DAL_Usuario user = new DAL_Usuario();
        public int role;
        public int id;
        public bool block;
        
        //INICIO DE SESION
        public bool login(string username, string password)
        {
            string HashedPassword= CryptoManager.HashPassword(password);
            
            bool sesion = user.Login(username, HashedPassword);
            if( sesion )
            {
                if (sessionManager.CheckSession == null)
                {
                    sessionManager.CreateSession(username);
                    BE_RegistroBitacora registroBitacora = new BE_RegistroBitacora(user.id, "Inicio de sesion", "Login");
                    
                    BLL_Bitacora bitacora = new BLL_Bitacora();
                    bitacora.BitacoraRegister(registroBitacora);
                    role = user.role;
                    id = user.id;
                    block = user.block;

                    //Actualizacion del DV en base de datos
                    _digitoManager.ActualizarTablaDVH("BITACORA_REGISTROS");
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

        public bool blockUser(string username)
        {
            bool complete = user.userBlock(username);
            _digitoManager.ActualizarTablaDVH("USUARIOS");
            return complete;
        }


        public void updatePassword(string username, string password)
        {
            string hashedpass = CryptoManager.HashPassword(password);
            user.updatePassword(username, hashedpass);
         
            _digitoManager.ActualizarTablaDVH("USUARIOS");
        }
    }
}
