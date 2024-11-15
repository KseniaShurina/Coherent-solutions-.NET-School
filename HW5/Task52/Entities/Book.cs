namespace Task52.Entities
{
    internal class Book
    {
        private string _title;
        public Isbn Isbn { get; set; } = null!;
        public DateTime? PublicationDate { get; set; }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be empty or null");
                }

                _title = value;
            }
        }

        public Book(string title, Isbn isbn, DateTime? publicationDate, IEnumerable<string>? authors = null)
        {
            _title = title;
            Isbn = isbn;
            PublicationDate = publicationDate;
            if (authors != null)
            {
                foreach (var author in authors)
                {
                    Authors.Add(author);
                }
            }
        }

        // A collection of non-repeating strings, possibly empty
        public HashSet<string> Authors = new HashSet<string>();

        public override string ToString()
        {
            return $"{Title} {PublicationDate} {Isbn}";
        }
    }
}
