using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SECURITY
{
    public class SessionManager
    {
        public string username;

        public SessionManager currentSession;

        //VERIFICAR SI EXISTE SESION
        public SessionManager CheckSession
        {
            get
            {
                return currentSession;
            }
        }

        //CREAR SESION
        public void CreateSession(string username)
        {
            currentSession = new SessionManager();
            currentSession.username = username;
        }

        //ELIMINAR SESION
        public void DeleteSession()
        {
            currentSession=null;
        }
    }
}
