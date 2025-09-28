namespace RuntimeErrors {
    public class Book {
        public string BookTitle { get; set; }
        public decimal Price { get; set; }

        public Book(string bookTitle, decimal price) {
            BookTitle = bookTitle;
            Price = price;
        }
    }
}
