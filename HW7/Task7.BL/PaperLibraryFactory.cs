using Task7.BL.Interfaces;
using Task7.DAL.Entities;

namespace Task7.BL;

public class PaperLibraryFactory : ILibraryAbstractFactory
{
    public PaperLibraryFactory() { }

    public Library CreateLibrary(Catalog catalog)
    {
        var books = catalog.GetAllBooks();
        if (books.Any(b => b is not PaperBook))
        {
            throw new ArgumentException("Invalid format of books");
        }

        var library = new Library(catalog);
        // For PaperBooks catalog - list of all publishers
        library.PressReleaseItems = books.OfType<PaperBook>().Select(b => b.Publisher).Distinct().ToList();

        return library;
    }
}

