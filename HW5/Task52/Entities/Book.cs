using Task52.Validators;

namespace Task52.Entities
{
    internal class Book
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be empty or null");
                }

                _title = value;
            }
        }

        public Isbn Isbn { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }

        // A collection of non-repeating strings, possibly empty
        public List<Author>? Authors = new List<Author>();

        public void AddAuthor(Author author)
        {
            if (EntityValidator.AcceptAuthor(author))
            {
                if (!Authors.Contains(author))
                {
                    Authors!.Add(author);
                }
            }
        }

        public List<(string, string)>? GetAuthors()
        {
            return Authors?.Select(a => (a.FirstName, a.LastName)).ToList() ?? null;
        }

        public void RemoveAuthor(Author author)
        {
            Authors?.Remove(author);
        }

        public override string ToString()
        {
            return $"{Title} {PublicationDate} {Isbn}";
        }
    }
}
