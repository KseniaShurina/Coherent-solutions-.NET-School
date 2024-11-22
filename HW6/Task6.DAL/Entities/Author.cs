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
                Books = new HashSet<Book>(books);
            }
        }
        public void AddBook(Book book)
        {
            if (EntityValidator.AcceptBook(book))
            {
                Books!.Add(book);
            }
        }

        public override string ToString() => $"{FirstName} {LastName} {DateOfBirthday?.ToShortDateString() ?? null})";
    }
}