using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GestionIdioma
    {
        public Dictionary<string, string> GetTextsByLanguage(string codigoIdioma)
        {
            var textos = new Dictionary<string, string>();

            
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                
                using (SqlCommand command = new SqlCommand(
                    "SELECT t.TextKey, t.Value " +
                    "FROM TEXTOIDIOMA t " +
                    "INNER JOIN IDIOMA l ON t.LanguageID = l.LanguageID " +
                    "WHERE l.LanguageCode = @idioma", connection))
                {
                    command.Parameters.AddWithValue("@idioma", codigoIdioma);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Llena el diccionario con las claves y valores obtenidos de la consulta
                            textos[reader["TextKey"].ToString()] = reader["Value"].ToString();
                        }
                    }
                }
            }

            return textos;
        }

        public Dictionary<string, string> GetTextsByLanguageId(int idiomaId)
        {
            var textos = new Dictionary<string, string>();

            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand(
                    "SELECT t.TextKey, t.Value " +
                    "FROM TEXTOIDIOMA t " +
                    "INNER JOIN IDIOMA l ON t.LanguageID = l.LanguageID " +
                    "WHERE l.LanguageID = @idiomaID", connection))
                {
                    command.Parameters.AddWithValue("@idiomaID", idiomaId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Llena el diccionario con las claves y valores obtenidos de la consulta
                            textos[reader["TextKey"].ToString()] = reader["Value"].ToString();
                        }
                    }
                }
            }

            // Retorna el diccionario de textos
            return textos;
        }

        public string ObtenerCodigoDesdeId(int id)
        {
            string respuesta = null; // predeterminado en caso de que no se encuentre el idioma.

            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT LanguageCode FROM IDIOMA WHERE LanguageID = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            respuesta = reader.GetString(0); // 0 es el índice de la columna LanguageCode
                        }
                    }
                }
            }

            return respuesta ?? "es-ES";
        }

        public int ObtenerIdDesdeIdioma(string codigoIdioma)
        {
            int id = -1; // Valor predeterminado en caso de que no se encuentre el idioma.

            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT LanguageID FROM IDIOMA WHERE LanguageCode = @idioma;", connection))
                {
                    command.Parameters.AddWithValue("@idioma", codigoIdioma);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                }
            }

            return id;
        }
    }
}
