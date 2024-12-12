using System.Xml.Serialization;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.DTO;
using Task7.DAL.DtoExtensionHelper;
using Task7.DAL.Validators;

namespace Task7.DAL.Repositories;

public class XmlRepository : IRepository
{
    public XmlRepository() { }

    private const string Path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\XML files\catalog.xml";

    public void Save(Catalog catalog)
    {
        if (catalog == null)
        {
            throw new ArgumentNullException(nameof(catalog));
        }

        var dtoCatalog = catalog.MapToDtoCatalog();

        XmlSerializer serializer = new XmlSerializer(typeof(DtoCatalog));

        using (FileStream file = new FileStream(Path, FileMode.Create))
        {
            serializer.Serialize(file, dtoCatalog);
        }
    }

    public Catalog? Get()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DtoCatalog));

        using (FileStream file = new FileStream(Path, FileMode.Open))
        {
            DtoCatalog? dtoCatalog = serializer.Deserialize(file) as DtoCatalog;

            if (dtoCatalog == null)
            {
                return null;
            }

            // Create new catalog
            Catalog catalog = new Catalog();

            //Add books to catalog and authors to each book
            foreach (var book in dtoCatalog.Books)
            {
                if (EntityValidator.IsIsbn(book.Identifiers[0]))
                {
                    catalog.AddBook(book.Identifiers[0], new PaperBook
                    (
                        book.Title,
                        new HashSet<Author>(book.Authors.Select(a =>
                            new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                        new List<string>(book.Identifiers),
                        //TODO: How to deal with specific properties if I avoid them?
                        null,
                        null)
                    );
                }
                else
                {
                    catalog.AddBook(book.Identifiers[0], new EBook
                    (
                        book.Title,
                        new HashSet<Author>(book.Authors.Select(a =>
                            new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                        book.Identifiers[0])
                    );
                }
            }
            return catalog;
        }
    }
}
