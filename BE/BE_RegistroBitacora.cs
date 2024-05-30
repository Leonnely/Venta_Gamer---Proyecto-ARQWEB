using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_RegistroBitacora
    {
        public string Autor { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }

        public BE_RegistroBitacora(string autor, string mensaje, string modulo)
        {
            Autor = autor;
            Fecha=DateTime.Now;
            Mensaje = mensaje;
            Modulo = modulo;
            
        }


    }
}
