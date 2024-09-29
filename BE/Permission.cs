using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public class Permission: IComposite
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}
