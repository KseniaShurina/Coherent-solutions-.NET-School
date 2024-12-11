namespace Task7.DAL.Entities;

public class Library
{
    // all books are `PaperBook` or all books are `EBook`
    public Catalog Catalog { get; set; }
    // For PaperBooks catalog - list of all publishers, for EBook catalog - list of all available electronic formats
    public List<string> PressReleaseItems { get; set; }
    public Library(Catalog catalog)
    {
        Catalog = catalog;
    }

    private void AddPressReleaseItem(string item)
    {
        if (!PressReleaseItems.Contains(item))
        {
            PressReleaseItems.Add(item);
        }
    }

    public List<string> GetPressReleaseItems()
    {
        return PressReleaseItems;
    }
}