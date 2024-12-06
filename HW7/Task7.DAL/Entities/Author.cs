namespace Task7.DAL.Entities
{
    public class Author
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? DateOfBirthday { get; }

        private const byte _sizeOfName = 200;

        public Author(string firstName, string lastName, DateTime? dateOfBirthday)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > _sizeOfName)
            {
                throw new ArgumentException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > _sizeOfName)
            {
                throw new ArgumentException(nameof(lastName));
            }
            
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
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