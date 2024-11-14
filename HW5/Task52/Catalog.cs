using System.Text.RegularExpressions;

namespace Task52
{
    internal class Catalog
    {
        // string - ISBN 
        private Dictionary<string, Book> Books = new Dictionary<string, Book>();

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (book.Isbn == null) throw new ArgumentNullException("ISBN is null");
            if (book.Title == null) throw new ArgumentNullException("Title is null");
            Books!.Add(book.Isbn.ToString(), book);
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
            var result = Books.Values.Where(b =>
                b.Authors.Contains(author))
                .OrderBy(b => b.PublicationDate)
                .ToList();
            return result;
        }

        // TODO Get from the catalog a set of tuples of the form “author’s name – the number of his books in the catalog” for all authors.
        public List<(Author, int)> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        //TODO Method for future tasks
        public Book GetBookByIsbn(string isbn)
        {
            // the pattern "\D" represents any character that is not a digit
            Regex regex = new Regex(@"\D");

            var book = Books
                .Where(b => b.Key == regex.Replace(isbn, ""))
                .Select(b => b.Value)
                .FirstOrDefault();
            if (book == null) new ArgumentNullException(nameof(book));

            return book;
        }
    }
}
