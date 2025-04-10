using System;
using System.Data.SqlClient;
using static Transport_Management_System.Exception_Handling.ExceptionHandling;

namespace Utilities
{
    public class DataBaseConnector
    {

        public static SqlConnection GetConnection()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-FKC1CCN\\SQLEXPRESS01;Initial Catalog=Transport_Management_System;Integrated Security=True";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Database connection failed: " + ex.Message);
            }



        }
    }

}

