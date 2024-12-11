using Task7.BL.Interfaces;
using Task7.DAL.Entities;

namespace Task7.BL;

public class ELibraryFactory : ILibraryAbstractFactory
{
    public ELibraryFactory() { }

    public Library CreateLibrary(Catalog catalog)
    {
        var books = catalog.GetAllBooks();
        if (books.Any(b => b is not EBook))
        {
            throw new ArgumentException("Invalid format of books");
        }

        var library = new Library(catalog);
        // For PaperBooks catalog - list of all available electronic formats
        library.PressReleaseItems = books.OfType<EBook>().SelectMany(b => b.Formats).Distinct().ToList();

        return library;
    }
}