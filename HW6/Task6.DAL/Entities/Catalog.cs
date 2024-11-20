using System.Xml.Serialization;
using Task6.DAL.Validators;

namespace Task6.DAL.Entities
{
    [XmlRoot("Catalog")]
    public class Catalog
    {
        [XmlIgnore]
        private readonly Dictionary<Isbn, Book> Books = new();

        public void AddBook(Book book)
        {
            if (EntityValidator.AcceptBook(book))
            {
                Books!.Add(book.Isbn, book);
            }
        }

        // Get a set of book titles from the catalog, sorted alphabetically.
        public List<string> GetBookTitles()
        {
            var result = Books
                .Select(b => b.Value.Title)
                .OrderBy(b => b)
                .ToList();

            return result;
        }

        // Retrieve from the catalog a set of books by the specified author name, sorted alphabetically.
        public List<Book> GetBooksByAuthor(Author author)
        {
            var books = Books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate)
                .ToList();

            return books;
        }

        // Get from the catalog a set of tuples of the form “author’s name – the number of his books in the catalog” for all authors.
        public List<(Author, int)> GetNumberOfBooksByAuthor()
        {
            var result = Books
                .SelectMany(a => a.Value.Authors)
                .GroupBy(author => author)
                .Select(group => (group.Key, group.Count())).ToList();

            return result;
        }

        // Get book by ISBN. If ISBN has format XXX-X-XX-XXXXXX-X, convert to XXXXXXXXXXXXX
        public Book? GetBookByIsbn(string isbn)
        {
            var convertedIsbn = IsbnConverter.ConvertIsbnToSimplifiedPattern(isbn);

            var book = Books
                .Where(b => b.Key.ToString() == convertedIsbn)
                .Select(b => b.Value)
                .FirstOrDefault();

            return book;
        }

        internal List<Book> GetAllBooks()
        {
            return Books.Values.ToList();
        }
    }
}
