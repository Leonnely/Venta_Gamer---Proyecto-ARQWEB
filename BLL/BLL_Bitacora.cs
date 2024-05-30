using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bitacora
    {

        DAL_Bitacora bitacora = new DAL_Bitacora();


        public void BitacoraRegister(BE_RegistroBitacora registroBitacora)
        {
            bitacora.BitacoraRegister(registroBitacora);
        }


    }
}
