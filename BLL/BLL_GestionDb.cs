using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_GestionDb
    {
        public bool CreateBackup(string myString)
        {
            DAL_GestionDB Manager = new DAL_GestionDB();
            if (Manager.CreateDatabase(myString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RestoreDatabase(string location)
        {
            DAL_GestionDB Manager = new DAL_GestionDB();
            if (Manager.RestoreDatabase(location))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
