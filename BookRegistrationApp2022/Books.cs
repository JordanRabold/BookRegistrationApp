

namespace BookRegistrationApp2022
{
    internal class Book
    {
        public Book(string ISBN, decimal Price, string Title)
        {
            BookISBN = ISBN;
            BookPrice = Price;
            BookTitle = Title;
        }

        public string BookISBN { get; set; }

        public decimal BookPrice { get; set; }

        public string BookTitle { get; set; }

        public override string ToString()
        {
            return BookTitle;
        }


    }
}
