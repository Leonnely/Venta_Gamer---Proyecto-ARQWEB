using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Bitacora
    {
        //ESCRITURA EN BITACORA
        public void BitacoraRegister(BE_RegistroBitacora registroBitacora)
        {
            zDatos.Bitacora.Add(registroBitacora);
        }

        //LECTURA DE BITACORA
        public List<BE_RegistroBitacora> getAll()
        {
            return zDatos.Bitacora;
        }
    }
}
