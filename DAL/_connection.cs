using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class _connection
    {
        private static readonly string _connectionString;

        // Constructor estático: inicializa la cadena de conexión
        static _connection()
        {
            //DESCOMENTAR LA LINEA DE ABAJO PARA Q LES ANDE Y COMENTAR LA DEL EXPRESS
            //_connectionString = @"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False";


            //COMENTEN LA LINEA DE ABAJO, XQ EN EL SQL EXPRESS ME ANDA CON ESTO NOMAS - LEO
            _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VentaGamer;Integrated Security=True";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
