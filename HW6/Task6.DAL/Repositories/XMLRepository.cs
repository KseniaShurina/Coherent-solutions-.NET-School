using System.Xml.Serialization;
using Task6.DAL.DTO;
using Task6.DAL.DTOExtensions;
using Task6.DAL.Entities;
using Task6.DAL.Interfaces;

namespace Task6.DAL.Repositories
{
    public class XMLRepository : IRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW6\Files\XML files\catalog.xml";
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
                dtoCatalog.Books.ForEach(book => catalog.AddBook(new Book(
                        book.Title,
                        new Isbn(book.Isbn),
                        book.PublicationDate,
                        book.Authors.Select(author => new Author(
                            author.FirstName,
                            author.LastName,
                            author.DateOfBirthday)) ?? throw new ArgumentNullException(nameof(book.Authors)))));

                return catalog;
            }
        }
    }
}
