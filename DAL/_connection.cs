﻿using System;
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

        static _connection()
        {
<<<<<<< HEAD
            //_connectionString = @"Data Source=DESKTOP-P9QCU60\MSSQLSERVER01;Initial Catalog=VentaGamer;Integrated Security=True";

            _connectionString = @"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False";
=======
            _connectionString = @"Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True";
>>>>>>> 08f465c1e646fecf45bff734d5baebe9c602767e
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
