using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_RegistroBitacora
    {
        public int Autor { get; set; }

        public string user { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }

        public BE_RegistroBitacora(int autor, string mensaje, string modulo)
        {
            Autor = autor;
            Fecha=DateTime.Now;
            Mensaje = mensaje;
            Modulo = modulo;
            
        }

        public BE_RegistroBitacora(string mensaje, DateTime fecha, string modulo)
        {
            Autor = 0;
            Fecha = fecha;
            Mensaje = mensaje;
            Modulo = modulo;

        }

        public BE_RegistroBitacora()
        {
            
        }

        //protected DateTime generateDate()
        //{
        //    Random rnd = new Random();

        //    // Definir el rango de fechas
        //    DateTime startDate = new DateTime(2000, 1, 1); // Fecha mínima
        //    DateTime endDate = DateTime.Now; // Fecha máxima (puedes ajustar esta fecha)

        //    // Calcular el rango en días
        //    int range = (endDate - startDate).Days;

        //    // Generar un número aleatorio dentro del rango y sumarlo a la fecha mínima
        //    DateTime randomDate = startDate.AddDays(rnd.Next(range)).AddSeconds(rnd.Next(86400)); // 8640
        //    return randomDate;
        //}
    }
}
