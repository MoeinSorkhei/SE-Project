using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SAD
{
    class DBConnection
    {
        private string connectionString = @"Data Source=MAAZ\SQLEXPRESS;
                                          Initial Catalog=db_SAD;
                                          Integrated Security=True;
                                          Connect Timeout=15;Encrypt=False;
                                          TrustServerCertificate=False;
                                          ApplicationIntent=ReadWrite;
                                          MultiSubnetFailover=False";
        private SqlConnection connection;
        public DBConnection()
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<SqlDataReader> RunSelectQuery(string query)
        {
            List<SqlDataReader> result = new List<SqlDataReader>();
            try
            {
                SqlCommand sqlComm = new SqlCommand(query, connection);
                using (SqlDataReader reader = sqlComm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void RunOtherQuery(string query)
        {
            try
            {
                SqlCommand sqlComm = new SqlCommand(query, connection);
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
