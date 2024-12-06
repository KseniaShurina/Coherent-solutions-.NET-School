namespace Task7.DAL.Entities
{
    internal class Library
    {
        // all books are `PaperBook` or all books are `EBook`
        public Catalog Catalog { get; set; }
        public List<string> PressReleaseItems { get; set; }

        public Library(Catalog catalog, IEnumerable<string> pressReleaseItems)
        {

        }
    }
}
