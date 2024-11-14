namespace Task52
{
    internal class Author
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public List<Book> Books = new List<Book>();

        public void AddBook(Book? book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (AcceptBook(book))
            {
                Books?.Add(book);
            }
        }

        private bool AcceptBook(Book? book)
        {
            if (book == null) return false;

            if (book.Authors == null) throw new ArgumentNullException(nameof(book.Authors));

            if (book is not Book && !book.Authors.Any(a => a.FirstName == FirstName || a.LastName == LastName))
            {
                return false;
            }
            return true;
        }
    }
}
