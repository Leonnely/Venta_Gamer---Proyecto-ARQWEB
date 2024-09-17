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
        DAL_Usuario user = new DAL_Usuario();
        public int role;
        public int id;
        public bool block;
        public int languageID;
        
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
                    //DVManager managerSecurity = new DVManager();
                    //managerSecurity.guardarTable(managerSecurity.HashTable("BITACORA_REGISTROS"), "DV_BITACORA");
                    DVManager.guardarTable(DVManager.HashTable("BITACORA_REGISTROS"), "DV_BITACORA");
                    role = user.role;
                    id = user.id;
                    block = user.block;
                    languageID = user.language;
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
            DVManager.guardarTable(DVManager.HashTable("USUARIOS"), "DV_USUARIOS");
            return complete;
        }


        public void updatePassword(string username, string password)
        {
            string hashedpass = CryptoManager.HashPassword(password);
            user.updatePassword(username, hashedpass);
            DVManager.guardarTable(DVManager.HashTable("USUARIOS"), "DV_USUARIOS");
        }
    }
}
