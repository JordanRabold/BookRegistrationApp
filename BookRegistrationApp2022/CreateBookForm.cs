using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationApp2022
{
    public partial class CreateBookForm : Form
    {
        public CreateBookForm()
        {
            InitializeComponent();
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string isbn = textBoxISBN.Text;
            decimal bookPrice = Convert.ToDecimal(textBoxPrice.Text);
            string bookTitle = textBoxTitle.Text;

            if(isValid(isbn, bookPrice, bookTitle))
            {
                Book book = new Book(isbn, bookPrice, bookTitle);

                BookDB.AddBook(book);
                MessageBox.Show("Book added successfully");
                Close();
            }

        }

        private bool isValid(string isbn, decimal bookPrice, string bookTitle)
        {
            int numericValueISBN;
            bool isNumberISBN = int.TryParse(isbn, out numericValueISBN);

            //double numericValueBookPrice;
            if (!((bookPrice % 1) > 0))
            {
                MessageBox.Show("Book Price must be a number in decimal format");
                return false;
            }

            else if (!isNumberISBN || String.IsNullOrEmpty(textBoxISBN.Text))
            {
                MessageBox.Show("ISBN must be composed of only digits");
                return false;
            }

            else if (String.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Must enter Book Title");
                return false;
            }

            return true;
        }
    }
}
