using System.Data.SqlClient;

namespace BookRegistrationApp2022
{
    static class CustomerDB
    {

        public static void AddCustomer(Customer c)
        {
            // Establish connection to database
            SqlConnection connection = GetDatabaseConnection();

            // Prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = connection;

            // Parameterized Query
            insertCmd.CommandText = "INSERT INTO Customer(DateOfBirth, FirstName, LastName, Title)" +
                "VALUES (@DateOfBirth, @FirstName, @LastName, @Title)"; // DO NOT CONCATENATE VALUES
            insertCmd.Parameters.AddWithValue("@DateOfBirth", c.DOB);
            insertCmd.Parameters.AddWithValue("@FirstName", c.FName);
            insertCmd.Parameters.AddWithValue("@LastName", c.LName);
            insertCmd.Parameters.AddWithValue("@Title", c.CustTitle);

            // Open connection to the database 
            connection.Open();

            // Execute insert query
            insertCmd.ExecuteNonQuery();

            // Close connection to the database
            connection.Close();
        }
        public static SqlConnection GetDatabaseConnection()
        {
            return new SqlConnection(@"Data Source=LAPTOP-2MFDVTGN\SQLEXPRESS;Initial Catalog=BookRegistration;Integrated Security=True;");
        }

        public static List<Customer> GetAllCustomers()
        {
            // Get Connection 
            SqlConnection connection = GetDatabaseConnection();

            // Prepare the Query
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = connection;
            selectCmd.CommandText = "SELECT CustomerID, DateOfBirth, FirstName, LastName, Title FROM Customer ORDER BY FirstName";

            // Open connection
            connection.Open();

            // Execute the query and user results
            SqlDataReader reader = selectCmd.ExecuteReader();

            List<Customer> customers = new(); // Create list of customers
            while (reader.Read())
            {
                int custID = Convert.ToInt32(reader["CustomerID"]); // read data from current row
                DateTime date = Convert.ToDateTime(reader["DateOfBirth"]); // read data from current row
                string? fName = reader["FirstName"].ToString(); // read data from current row
                string? lName = reader["LastName"].ToString(); // read data from current row
                string? custTitle = reader["Title"].ToString(); // read data from current row

                Customer tempCustomers = new Customer(date, fName, lName, custTitle); // Create Customer
                tempCustomers.CustomerID = custID;

                customers.Add(tempCustomers); // Add Customer to list
            }

            // Close connection to the database
            connection.Close();

            // Return list of books
            return customers;

        }
    }
}
