using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CommonLibs.Utils
{
    public class DatabaseUtils
    {
        //1. Create a connection with the database
        //2. Prepare the SQL Query
        //3. Execute the query -- Select Query --> Response (DataTable). For Non-Select query --> int
        //4. Process the data
        //5. Close the connection

        private SqlConnection connection;

        public void CreateConnection()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                UserID = "saurabh",
                Password = "admin@1234",
                InitialCatalog = "TestComplete"
            };

            connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

        }

        public void CloseConnection() => connection.Close();

        public DataTable ExecuteSelectQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(reader);

            return dataTable;

        }

        public int ExecuteNonSelectQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;

        }
    }
}
