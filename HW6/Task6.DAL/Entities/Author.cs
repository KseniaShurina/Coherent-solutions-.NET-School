using Task6.DAL.Validators;

namespace Task6.DAL.Entities
{
    public class Author
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? DateOfBirthday { get; }

        public HashSet<Book>? Books { get; } = new();

        public Author(string firstName, string lastName, DateTime? dateOfBirthday, IEnumerable<Book>? books = null)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 200)
            {
                throw new ArgumentException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 200)
            {
                throw new ArgumentException(nameof(lastName));
            }
            
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;

            if (books != null)
            {
                foreach (var book in books)
                {
                    AddBook(book);
                }
            }
        }

        public void AddBook(Book book)
        {
            if (!EntityValidator.AcceptBook(book))
            {
                throw new ArgumentException("Book is not correct.");
            }

            if (Books == null)
            {
                throw new ArgumentNullException(nameof(Books));
            }

            Books.Add(book);
        }

        public override string ToString() => $"{FirstName} {LastName} {DateOfBirthday?.ToShortDateString() ?? null})";

        public override bool Equals(object? obj)
        {
            if (obj is not Author author)
            {
                return false;
            }

            // && (And) checks that all conditions are true.
            if (FirstName != author.FirstName && LastName != author.LastName && DateOfBirthday != author.DateOfBirthday)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirthday);
        }
    }
}