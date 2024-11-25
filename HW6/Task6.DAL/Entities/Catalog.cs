using Task6.DAL.Validators;

namespace Task6.DAL.Entities
{
    /// <summary>
    /// Represents a catalog of books, allowing for various operations such as adding books,
    /// retrieving books by author, title, or ISBN, and generating reports about authors and their books.
    /// </summary>
    public class Catalog
    {
        private readonly Dictionary<Isbn, Book> Books = new();

        /// <summary>
        /// Adds a book to the catalog if it passes validation.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the book fails validation or already exists in the catalog.</exception>
        public void AddBook(Book book)
        {
            if (EntityValidator.AcceptBook(book))
            {
                Books!.Add(book.Isbn, book);
            }
        }

        /// <summary>
        /// Get a set of book titles from the catalog, sorted alphabetically.
        /// </summary>
        /// <returns></returns>
        public List<string> GetBookTitles()
        {
            var result = Books
                .Select(b => b.Value.Title)
                .OrderBy(b => b)
                .ToList();

            return result;
        }

        /// <summary>
        /// Retrieve from the catalog a set of books by the specified author name, sorted alphabetically.
        /// </summary>
        /// <param name="author"></param>
        /// <returns>A list of tuples where each tuple contains an author and their corresponding book count.</returns>
        public List<Book> GetBooksByAuthor(Author author)
        {
            var books = Books.Values
                .Where(b => b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate)
                .ToList();

            return books;
        }

        /// <summary>
        /// Get from the catalog a set of tuples of the form “author’s name – the number of his books in the catalog” for all authors.
        /// </summary>
        /// <returns>A list of tuples where each tuple contains an author and their corresponding book count.</returns>
        public List<(Author, int)> GetNumberOfBooksByAuthor()
        {
            var result = Books
                .SelectMany(a => a.Value.Authors)
                .GroupBy(author => author)
                .Select(group => (group.Key, group.Count())).ToList();

            return result;
        }

        /// <summary>
        /// Get book by ISBN. If ISBN has format XXX-X-XX-XXXXXX-X, convert to XXXXXXXXXXXXX
        /// </summary>
        /// <param name="isbn">The ISBN of the book to retrieve.</param>
        /// <returns>The book with the specified ISBN, or null if no book is found.</returns>
        public Book? GetBookByIsbn(string isbn)
        {
            var convertedIsbn = IsbnConverter.ConvertIsbnToSimplifiedPattern(isbn);

            var book = Books
                .Where(b => b.Key.ToString() == convertedIsbn)
                .Select(b => b.Value)
                .FirstOrDefault();

            return book;
        }

        /// <summary>
        /// Retrieves all books currently stored in the catalog.
        /// </summary>
        /// <returns>A list of all books in the catalog.</returns>
        public List<Book> GetAllBooks()
        {
            return Books.Values.ToList();
        }
    }
}
