using System.Data.SqlClient;

namespace BookRegistrationApp2022
{
    static class BookDB
    {
        public static void AddBook(Book b)
        {
            // Establish connection to database
            SqlConnection con = GetDatabaseConnection();

            // Prepare insert statement
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;

            // Parameterized Query
            insertCmd.CommandText = "INSERT INTO Book(ISBN, Price, Title)" +
                "VALUES (@ISBN, @Price, @Title)"; 
            insertCmd.Parameters.AddWithValue("@ISBN", b.BookISBN);
            insertCmd.Parameters.AddWithValue("@Price", b.BookPrice);
            insertCmd.Parameters.AddWithValue("@Title", b.BookTitle);

            // Open connection to the database 
            con.Open();

            // Execute insert query
            insertCmd.ExecuteNonQuery();

            // Close connection to the database
            con.Close();
        }

        public static SqlConnection GetDatabaseConnection()
        {
            return new SqlConnection(@"Data Source=LAPTOP-2MFDVTGN\SQLEXPRESS;Initial Catalog = BookRegistration;Integrated Security=True;");
        }

        public static List<Book> GetAllBooks()
        {
            // Get Connection 
            SqlConnection connection = GetDatabaseConnection();

            // Prepare the Query
            SqlCommand selectCmd = new SqlCommand();
            selectCmd.Connection = connection;
            selectCmd.CommandText = "SELECT ISBN, Price, Title FROM Book ORDER BY Title";

            // Open connection
            connection.Open();

            // Execute the query and user results
            SqlDataReader reader = selectCmd.ExecuteReader();

            List<Book> books = new(); // Create list of books
            while (reader.Read())
            {
                string? isbn = reader["ISBN"].ToString(); // read data from current row
                decimal bookPrice = Convert.ToDecimal(reader["Price"]); // read data from current row
                string? bookTitle = reader["Title"].ToString(); // read data from current row

                Book tempBook = new Book(isbn, bookPrice, bookTitle); // Create Book

                books.Add(tempBook); // Add Book to list
            }

            // Close connection to the database
            connection.Close();

            // Return list of books
            return books;

        }
    }
}
