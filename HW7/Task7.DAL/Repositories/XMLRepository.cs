using System.Xml.Serialization;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.DTO;
using Task7.DAL.DTOExtensions;
using Task7.DAL.Validators;

namespace Task7.DAL.Repositories
{
    public class XMLRepository : IRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\XML files\catalog.xml";
        public XMLRepository() { }

        public void Save(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new ArgumentNullException(nameof(catalog));
            }

            var dtoCatalog = catalog.MapToDTOCatalog();

            XmlSerializer serializer = new XmlSerializer(typeof(DTOCatalog));

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, dtoCatalog);
            }
        }

        public Catalog? Get()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DTOCatalog));

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                DTOCatalog? dtoCatalog = serializer.Deserialize(file) as DTOCatalog;

                if (dtoCatalog == null)
                {
                    return null;
                }

                // Create new catalog
                Catalog catalog = new Catalog();

                // Add books to catalog and authors to each book
                //foreach (var book in dtoCatalog.Books)
                //{
                //    if (EntityValidator.IsIsbn(book.Identifiers[0]))
                //    {
                //        catalog.AddBook(book.Identifiers[0], new PaperBook
                //        {
                //            Title = book.Title,
                //            Isbns = book.Identifiers,
                //            Authors = (HashSet<Author>)book.Authors!.Select(a => new Author(a.FirstName, a.LastName, a.DateOfBirthday))
                //        });
                //    }
                //    else
                //    {
                //        catalog.AddBook(book.Identifiers[0], new EBook
                //        {
                //            Title = book.Title,
                //            Identifier = book.Identifiers[0],
                //            Authors = (HashSet<Author>)book.Authors!.Select(a =>
                //                new Author(a.FirstName, a.LastName, a.DateOfBirthday))
                //        });
                //    }

                //}
                //return catalog;
                throw new NotImplementedException();
            }
        }
    }
}
