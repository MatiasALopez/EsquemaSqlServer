using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsquemaSqlServer
{
    public class SqlServerSchema
    {
        public SqlServerSchema(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");

            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }

        public DataTable ObtenerDatos(string nombreColeccion, string[] restricciones = null)
        {
            if (String.IsNullOrWhiteSpace(nombreColeccion))
                throw new ArgumentNullException("nombreColeccion");

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    if (restricciones == null)
                        return sqlConnection.GetSchema(nombreColeccion);

                    return sqlConnection.GetSchema(nombreColeccion, restricciones);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}