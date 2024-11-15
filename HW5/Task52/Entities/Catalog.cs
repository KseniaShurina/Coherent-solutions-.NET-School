using Task52.Validators;

namespace Task52.Entities
{
    internal class Catalog
    {
        // string - ISBN 
        private Dictionary<Isbn, Book> Books = new Dictionary<Isbn, Book>();

        public void AddBook(Book book)
        {
            if (EntityValidator.AcceptBook(book))
            {
                Books!.Add(book.Isbn, book);
            }
        }

        // Get a set of book titles from the catalog, sorted alphabetically.
        public List<string> GetBookTittles()
        {
            var result = Books.Select(b => b.Value.Title).OrderBy(b => b).ToList();
            return result;
        }

        // Retrieve from the catalog a set of books by the specified author name, sorted alphabetically.
        public List<Book> GetBooksByAuthor(Author author)
        {
            var books = Books.Values.Where(b =>
                b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate)
                .ToList();

            ArgumentNullException.ThrowIfNull(books);

            return books;
        }

        // TODO Get from the catalog a set of tuples of the form “author’s name – the number of his books in the catalog” for all authors.
        public List<(Author, int)> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        //TODO Method for future tasks
        public Book GetBookByIsbn(string isbn)
        {
            var convertedIsbn = IsbnConverter.ConvertIsbnToCommonPattern(isbn);

            var book = Books
                .Where(b => b.Key.ToString() == convertedIsbn)
                .Select(b => b.Value)
                .FirstOrDefault();

            ArgumentNullException.ThrowIfNull(book);

            return book;
        }
    }
}
