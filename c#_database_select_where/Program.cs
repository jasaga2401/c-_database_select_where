using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for the SQL Server database
        string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=things_to_do;Integrated Security=True";

        // Variable for the WHERE clause
        int categoryId = 1;

        // SQL SELECT query with a WHERE clause
        string sqlQuery = $"SELECT * FROM dbo.tbl_items WHERE itid = {categoryId}";

        // Create a SqlConnection and execute the query
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Check if there are rows returned
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Access columns using reader
                            int itid = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            Console.WriteLine($"Item ID: {itid}, Item Name: {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }
            }
        }
    }
}

