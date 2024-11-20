namespace Task6.DAL.Entities
{
    public class Author
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime? DateOfBirthday { get; }

        public Author(string firstName, string lastName, DateTime? dateOfBirthday)
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
        }

        public override string ToString() => $"{FirstName} {LastName} {DateOfBirthday?.ToShortDateString() ?? null})";
    }
}