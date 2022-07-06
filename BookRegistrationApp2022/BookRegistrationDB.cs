using System.Data.SqlClient;

namespace BookRegistrationApp2022
{
    internal class BookRegistrationDB
    {

        public static SqlConnection GetDatabaseConnection()
        {
            return new SqlConnection(@"Data Source=LAPTOP-2MFDVTGN\SQLEXPRESS;Initial Catalog=BookRegistration;Integrated Security=True;");
        }

        public static void AddRegistration(Registration r)
        {
            // Establish connection to database
            SqlConnection connection = GetDatabaseConnection();

            // Prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = connection;

            // Parameterized Query
            insertCmd.CommandText =
                "INSERT INTO Registration(CustomerID, ISBN, RegDate)" +
                "VALUES(@CustomerID, @ISBN, @RegDate)";
               
            insertCmd.Parameters.AddWithValue("@CustomerID", r.CustID);
            insertCmd.Parameters.AddWithValue("@ISBN", r.BookISBN);
            insertCmd.Parameters.AddWithValue("@RegDate", r.DateRegistered);

            // Open connection to the database 
            connection.Open();

            // Execute insert query
            insertCmd.ExecuteNonQuery();

            // Close connection to the database
            connection.Close();
        }
    }
}
