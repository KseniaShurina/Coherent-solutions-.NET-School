namespace Task52.Entities
{
    internal class Author
    {
        public required string Name { get; set; }

        public HashSet<Book> Books = new HashSet<Book>();

        public Author(string name)
        {
           Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
