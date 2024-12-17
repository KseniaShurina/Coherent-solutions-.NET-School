using System.Xml.Serialization;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.DTO;
using Task7.DAL.Validators;
using Task7.DAL.DtoExtensions;

namespace Task7.DAL.Repositories;

public class XmlRepository : IRepository
{
    public XmlRepository() { }

    private const string Path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\XML files\books.xml";

    public async Task Save(Library library)
    {
        if (library == null)
        {
            throw new ArgumentNullException(nameof(library));
        }

        var listOfDtoBooks = library.Catalog.GetAllBooks().Select(book => book.MapToDtoBook()).ToList();

        XmlSerializer serializer = new XmlSerializer(typeof(List<DtoBook>));

        using (FileStream file = new FileStream(Path, FileMode.Create))
        {
            serializer.Serialize(file, listOfDtoBooks);
        }
    }

    //TODO: Create a separate method for creating books
    public async Task<List<Book>> Get()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<DtoBook>));

        using (FileStream file = new FileStream(Path, FileMode.Open))
        {
            List<DtoBook>? listOfDtoBooks = serializer.Deserialize(file) as List<DtoBook>;

            if (listOfDtoBooks == null)
            {
                return null;
            }

            var listOfBooks = new List<Book>();
            //Add books to catalog and authors to each book
            foreach (var book in listOfDtoBooks)
            {
                if (EntityValidator.IsIsbn(book.Identifiers[0]))
                {
                    var restoredPaperBook = new PaperBook(
                            book.Title,
                            new HashSet<Author>(book.Authors.Select(a =>
                                new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                            new List<string>(book.Identifiers),
                            //TODO: How to deal with specific properties if I avoid them?
                            null,
                            null);

                    //TODO: Which approach is more useful? Throw exception if book doesn't accepted or add book to catalog if it accepted (row 79)?
                    if (!EntityValidator.AcceptBook(restoredPaperBook))
                    {
                        throw new ArgumentException("An error occurred while converting the book");
                    }

                    listOfBooks.Add(restoredPaperBook);
                }
                else
                {
                    var restoredEBook = new EBook(
                        book.Title,
                        new HashSet<Author>(book.Authors.Select(a =>
                            new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                        book.Identifiers[0]);

                    if (EntityValidator.AcceptBook(restoredEBook))
                    {
                        listOfBooks.Add(restoredEBook);
                    }
                }
            }
            return listOfBooks;
        }
    }
}
