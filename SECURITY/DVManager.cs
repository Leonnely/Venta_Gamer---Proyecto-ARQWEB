using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SECURITY
{
    public  class DVManager
    {
        static DVManager() { }

        private readonly DALDVManager DAL_DVManager = new DALDVManager();

        public DataTable ValidarDVH(string nombreTabla)
        {
            return DAL_DVManager.ValidarDVH(nombreTabla);
        }

        public bool ActualizarTablaDVH(string nombreTabla)
        {
            return DAL_DVManager.ActualizarTablaDVH(nombreTabla);
        }

        public List<DataTable> CheckIntegrity()
        {
            List<DataTable> dataTables = new List<DataTable>();

            // Lista de nombres de tablas a validar
            string[] tablesToCheck = { "USUARIOS", "BITACORA_REGISTROS" };

            foreach (string tableName in tablesToCheck)
            {
                DataTable dt = this.ValidarDVH(tableName);
                if (dt != null)
                    dataTables.Add(dt);
            }

            return dataTables;
        }

    }
}
