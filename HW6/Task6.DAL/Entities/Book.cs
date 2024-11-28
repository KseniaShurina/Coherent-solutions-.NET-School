using Task6.DAL.Validators;

namespace Task6.DAL.Entities
{
    public class Book
    {
        public string Title { get; }
        public Isbn Isbn { get; } = null!;
        public DateTime? PublicationDate { get; }
        public HashSet<Author> Authors { get; } = new();

        public Book(string title, Isbn isbn, DateTime? publicationDate, IEnumerable<Author>? authors = null)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));

            Title = title;
            Isbn = isbn;
            PublicationDate = publicationDate;

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    AddAuthor(author);

                    // Add this book to the author
                    author.AddBook(this);
                }
            }
        }

        public void AddAuthor(Author author)
        {
            if (!EntityValidator.AcceptAuthor(author))
            {
                throw new ArgumentException("Author is not correct.");
            }

            if (Authors == null)
            {
                throw new ArgumentNullException(nameof(Authors));
            }

            Authors.Add(author);
        }

        public override string ToString()
        {
            return $"{Title} {PublicationDate?.ToShortDateString()} {Isbn}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book book)
            {
                return false;
            }

            if (!Authors.OrderBy(a => a.LastName).SequenceEqual(book.Authors.OrderBy(a => a.LastName)))
            {
                return false;
            }

            // && (And) checks that all conditions are true.
            if (Title != book.Title && Isbn != book.Isbn && PublicationDate != book.PublicationDate)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Isbn, PublicationDate);
        }
    }
}