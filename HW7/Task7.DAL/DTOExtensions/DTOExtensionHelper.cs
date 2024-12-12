using Task7.DAL.DTO;
using Task7.DAL.Entities;

namespace Task7.DAL.DTOExtensions;

internal static class DTOExtensionHelper
{
    public static DTOBook MapToDTOBook(this Book book)
    {
        var identifiers = new List<string>();
        if (book is PaperBook paperBook)
        {
            // Assign the list of ISBNs for PaperBook
            identifiers = paperBook.Isbns;
        }
        else if (book is EBook eBook)
        {
            // Assign the identifier for EBook
            identifiers.Add(eBook.Identifier);
        }
        return new DTOBook
        {
            Title = book.Title,
            Identifiers = identifiers,
            // To avoid System.StackOverflowException
            Authors = book.Authors!.Select(a => new DTOAuthor
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirthday = a.DateOfBirthday
            }).ToList(),
        };
    }

    public static DTOAuthor MapToDTOAuthor(this Author author)
    {
        return new DTOAuthor
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirthday = author.DateOfBirthday,
        };
    }

    public static DTOCatalog MapToDTOCatalog(this Catalog catalog)
    {
        DTOCatalog dtoCatalog = new DTOCatalog();
        var list = catalog.GetAllBooks();
        foreach (var book in list)
        {
            dtoCatalog.Books.Add(book.MapToDTOBook());
        }
        return dtoCatalog;
    }
}
