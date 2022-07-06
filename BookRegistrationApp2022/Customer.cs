

namespace BookRegistrationApp2022
{
    internal class Customer
    {
        public Customer(DateTime DateOfBirth, string FirstName, string LastName, string Title)
        {
            DOB = DateOfBirth;
            FName = FirstName;
            LName = LastName;
            CustTitle = Title;
        }

        private int _customerID;
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public DateTime DOB { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string CustTitle { get; set; }

        public override string ToString()
        {
            return FName + " " + LName;
        }

    }
}
