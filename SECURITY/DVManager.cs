using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
                dt.TableName = tableName;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataTables.Add(dt);
                }
            }

            return dataTables;
        }

        public DataTable CalcularDV()
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Tabla", typeof(string));
            resultTable.Columns.Add("Mensaje", typeof(string));

            string[] tablesToCheck = { "USUARIOS", "BITACORA_REGISTROS" };

            foreach (string tableName in tablesToCheck)
            {
                List<string> rowsArray = new List<string>(); // Inicializar la lista de cadenas
                string mensaje = "";

                // Validar DVH y obtener filas con discrepancias
                DataTable dta = this.ValidarDVH(tableName);
                if (dta != null && dta.Rows.Count > 0)
                {
                    rowsArray.AddRange(
                        dta.AsEnumerable()
                           .Select(row => $"{tableName},{string.Join(",", row.ItemArray)}")
                    );
                }

                // Calcular DV
                List<DataTable> dt = DAL_DVManager.CalcularDV(tableName);
                if (dt.Count < 2)
                {
                    resultTable.Rows.Add(tableName, "Error: No se pudieron calcular las tablas.");
                    continue;
                }

                DataTable dtCalculado = dt[0];
                DataTable dtOriginal = dt[1];
                dtCalculado.TableName = tableName + "_Calculado";
                dtOriginal.TableName = tableName + "_Original";

                // Comparar tablas
                if (!DataTablesAreEqual(dtCalculado, dtOriginal))
                {
                    mensaje = $"Se han modificado registros en: {tableName}.";

                    if (dtCalculado.Rows.Count > dtOriginal.Rows.Count)
                    {
                        mensaje += " Se ha agregado un registro.";
                    }
                    else if (dtCalculado.Rows.Count < dtOriginal.Rows.Count)
                    {
                        mensaje += " Se ha eliminado un registro.";
                    }
                    else if (dtCalculado.Rows.Count == dtOriginal.Rows.Count) 
                    {
                        mensaje += " Sin certeza de la accion.";
                    }

                    // Agregar detalles de discrepancias
                    foreach (string row in rowsArray)
                    {
                        string[] rowParts = row.Split(',');
                        if (rowParts.Length >= 4 && rowParts[0] == tableName)
                        {
                            mensaje += $"\nÍndice {rowParts[1]}, valor calculado {rowParts[2]} - valor guardado {rowParts[3]}.";
                        }
                    }

                    resultTable.Rows.Add(tableName, mensaje);
                }
            }


            return resultTable;

        }

        // Método para comparar si dos DataTables son iguales en contenido
        private bool DataTablesAreEqual(DataTable dt1, DataTable dt2)
        {
            if (dt1.Rows.Count != dt2.Rows.Count || dt1.Columns.Count != dt2.Columns.Count)
                return false;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (!Equals(dt1.Rows[i][j], dt2.Rows[i][j]))
                        return false;
                }
            }
            return true;
        }


    }
}
