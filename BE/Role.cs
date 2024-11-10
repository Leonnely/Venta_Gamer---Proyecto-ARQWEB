using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public class Role: IComposite
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public List<IComposite> Permissions { get; set; }
        public List<Role> SubRoles { get; set; }

        public Role()
        {
            Permissions = new List<IComposite>();
            SubRoles = new List<Role>();
        }
    }
}
