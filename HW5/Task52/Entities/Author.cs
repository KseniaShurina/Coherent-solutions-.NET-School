using Task52.Validators;

namespace Task52.Entities
{
    internal class Author
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public List<Book> Books = new List<Book>();

        public void AddBook(Book? book)
        {
            if (!EntityValidator.AcceptBook(book))
            {
                throw new ArgumentException("Book in not valid");
            }

            Books.Add(book!);
        }
    }
}
