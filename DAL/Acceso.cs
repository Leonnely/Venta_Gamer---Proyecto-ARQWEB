using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        // Abre una conexión desde el método estático de _connection
        private SqlConnection GetConnection()
        {
            return _connection.GetConnection();
        }

        public DataTable Read(string st, SqlParameter[] parametros)
        {
            using (SqlConnection cn = GetConnection())
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(st, cn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    if (parametros != null)
                    {
                        da.SelectCommand.Parameters.AddRange(parametros);
                    }
                    da.Fill(dt);
                }
                return dt;
            }
        }

        public int Write(string st, SqlParameter[] parametros)
        {
            int fa;
            using (SqlConnection cn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(st, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    cn.Open();
                    try
                    {
                        fa = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        fa = -1;
                    }
                }
            }
            return fa;
        }

        public object ExecuteScalar(string st, SqlParameter[] parametros)
        {
            object result;
            using (SqlConnection cn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(st, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    cn.Open();
                    try
                    {
                        result = cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

    }
}
