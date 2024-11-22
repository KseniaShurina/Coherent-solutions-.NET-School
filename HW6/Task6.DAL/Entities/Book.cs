namespace Task6.DAL.Entities
{
    public class Book
    {
        public string Title { get; }
        public Isbn Isbn { get; } = null!;
        public DateTime? PublicationDate { get; }
        public HashSet<Author> Authors { get; } = new();

        public Book(string title, Isbn isbn, DateTime? publicationDate, IEnumerable<Author> authors)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));

            Title = title;
            Isbn = isbn;
            PublicationDate = publicationDate;
            if (authors != null)
            {
                Authors = new HashSet<Author>(authors);
            }    
        }

        public override string ToString()
        {
            return $"{Title} {PublicationDate?.ToShortDateString()} {Isbn}";
        }
    }
}