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
    public partial class CreateCustomerForm : Form
    {
        public CreateCustomerForm()
        {
            InitializeComponent();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string suffix = textBoxPrefix.Text;
            DateTime dob = this.dateTimePickerDOB.Value.Date;

            if (isValid(firstName, lastName, suffix))
            {
                Customer cust = new Customer(dob, firstName, lastName, suffix);

                CustomerDB.AddCustomer(cust);
                MessageBox.Show("Customer added successfully");
                Close();
            }

        }

        private bool isValid(string firstName, string lastName, string suffix)
        {

            if (String.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First Name Is Required");
                return false;
            }

            else if (String.IsNullOrEmpty(textBoxLastName.Text))
            {
                MessageBox.Show("Last Name Is Required");
                return  false;
            }

            else if (String.IsNullOrEmpty(textBoxPrefix.Text))
            {
                MessageBox.Show("Prefix Is Required");
                return false;
            }

            return true;
        }
    }
}
