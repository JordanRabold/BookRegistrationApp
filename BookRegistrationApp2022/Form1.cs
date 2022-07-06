
namespace BookRegistrationApp2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateBookList();
            PopulateCustomerList();
        }

        private void PopulateBookList()
        {
            comboBoxBooks.Items.Clear();

            List<Book> books = BookDB.GetAllBooks();

            foreach (Book currBook in books)
            {
                comboBoxBooks.Items.Add(currBook);
            }
        }

        private void PopulateCustomerList()
        {
            comboBoxCustomer.Items.Clear();

            List<Customer> customers = CustomerDB.GetAllCustomers();

            foreach (Customer currCustomer in customers)
            {
                comboBoxCustomer.Items.Add(currCustomer);
            }
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Customer selectedCustomer = comboBoxCustomer.SelectedItem as Customer;
            Book selectedBook = comboBoxBooks.SelectedItem as Book;
            string registerDate = datePicker.Value.ToShortDateString();

            Registration reg = new Registration(selectedCustomer.CustomerID, selectedBook.BookISBN, registerDate);

            BookRegistrationDB.AddRegistration(reg);
            MessageBox.Show("Registration added successfully!");
            Close();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomerForm newCustomerForm = new CreateCustomerForm();
            newCustomerForm.ShowDialog();

            PopulateCustomerList();
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            CreateBookForm newBookForm = new CreateBookForm();
            newBookForm.ShowDialog();

            PopulateBookList();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}