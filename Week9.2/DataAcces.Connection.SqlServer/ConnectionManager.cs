using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace Week9._2.DataAcces.Connection.SqlServer
{
    public static class ConnectionManager
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection
                    {
                        ConnectionString = ConnectionString
                    };

                    connection.Open();
                }

                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error when connecting to database: {e.Message}");
                throw;
            }
        }
    }
}
