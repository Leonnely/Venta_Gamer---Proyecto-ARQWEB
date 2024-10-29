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
            _connectionString = @"Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
