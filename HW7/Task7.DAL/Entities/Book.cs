using Task7.DAL.Validators;

namespace Task7.DAL.Entities
{
    public class Book
    {
        public string Title { get; }
        public HashSet<Author>? Authors { get; } = new();

        public Book(string title, IEnumerable<Author>? authors = null)
        {
            Title = title;
            if (authors != null)
            {
                Authors = new HashSet<Author>(authors);
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
        public override string ToString() => $"Title: {Title}";

        public override bool Equals(object? obj)
        {
            if (obj is not Book book)
            {
                return false;
            }

            // && (And) checks that all conditions are true.
            if (Title != book.Title)
            {
                return false;
            }

            if (book.Authors != null && Authors != null && !Authors.OrderBy(a => a.LastName).SequenceEqual(book.Authors.OrderBy(a => a.LastName)))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Authors);
        }
    }
}