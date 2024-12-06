namespace Task7.DAL.Entities
{
    public class EBook : Book
    {
        public string Identifier { get; }
        // A list of available electronic formats.
        public List<string> Formats { get; private set; }

        public EBook(string title, string identifier, IEnumerable<string> formats, IEnumerable<Author>? authors = null) :base(title, authors)
        {
            Identifier = identifier;
            Formats = new List<string>(formats);
        }

        public override string ToString() => $"Title: {Title}, Identifier: {Identifier}";
    }
}
