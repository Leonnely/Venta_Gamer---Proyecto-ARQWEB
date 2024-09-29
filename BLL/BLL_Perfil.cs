using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Perfil
    {
        public List<Role> GetRoles()
        {
            return DAL_Perfil.GetRoles();
        }
    }
}
