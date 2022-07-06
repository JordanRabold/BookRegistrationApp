

namespace BookRegistrationApp2022
{
    internal class Registration
    {
        public Registration(int CustomerID, string ISBN, string RegDate)
        {
            CustID = CustomerID;
            BookISBN = ISBN;
            DateRegistered = RegDate;
        }

        public int CustID { get; set; }

        public string BookISBN { get; set; }

        public string DateRegistered { get; set; }

    }
}
