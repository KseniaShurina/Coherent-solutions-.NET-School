using System.Xml.Serialization;
using Task6.DAL.Interfaces;
using Task6.DAL.Repository;
using Task6.DAL.Validators;
using Task6.DAL.XMLEntities;

namespace Task6.DAL.Entities
{
    [XmlRoot("Catalog")]
    public class Catalog
    {
        [XmlIgnore]
        private readonly Dictionary<Isbn, Book> Books = new();
        private readonly IRepository _repository = new XMLRepository();

        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<XMLBook> AuxiliaryBooks
        {
            get
            {
                var list = new List<XMLBook>();
                foreach (var book in Books)
                {
                    list.Add(new XMLBook
                    {
                        Title = book.Value.Title,
                        Isbn = book.Key.ToString(),
                        PublicationDate = book.Value.PublicationDate,
                        Authors = book.Value.Authors?.Select(a => new XMLAuthor
                        {
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            DateOfBirthday = a.DateOfBirthday
                        }).ToList()
                    });
                }

                return list;
            }
            set
            {
                foreach (var book in value)
                {
                    AddBook(new Book(
                        book.Title,
                        new Isbn(book.Isbn),
                        book.PublicationDate,
                        book.Authors?.Select(a => new Author(
                            a.FirstName, 
                            a.LastName, 
                            a.DateOfBirthday)) ?? Enumerable.Empty<Author>()));
                }
            }
        }
        public Catalog() { }

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
    }
}
