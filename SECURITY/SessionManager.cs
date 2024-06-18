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
        public SessionManager CheckSession
        {
            get
            {
                return currentSession;
            }
        }
        public void CreateSession(string username)
        {
            currentSession = new SessionManager();
            currentSession.username = username;
        }
        public void DeleteSession()
        {
            currentSession=null;
        }
    }
}
