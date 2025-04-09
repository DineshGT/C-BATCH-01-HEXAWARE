using System;
using System.Data.SqlClient;

namespace HospitalManagementSystem.Utility_Services
{
    public class DataBaseConnector
    {
        private static SqlConnection conn;

        public static SqlConnection GetConnection()
        {
            if (conn == null) // then we can open new so..
            {
                // Direct hardcoded connection string
                string connString = "Data Source=DESKTOP-FKC1CCN\\SQLEXPRESS01;Initial Catalog=HospitalManagementSystem;Integrated Security=True;";
                conn = new SqlConnection(connString);
                conn.Open();
            }

            return conn;
        }
    }
}
