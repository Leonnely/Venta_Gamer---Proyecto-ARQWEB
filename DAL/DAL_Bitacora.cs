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

        public List<BE_RegistroBitacora> Bitacora = new List<BE_RegistroBitacora>();

        public void BitacoraRegister(BE_RegistroBitacora registroBitacora)
        {
            Bitacora.Add(registroBitacora);
        }



    }
}
