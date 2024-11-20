using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.DAL.Extensions
{
    public static class XMLCatalogExtension
    {
        public static XMLCatalog MapToXMLCatalog(this Catalog catalog)
        {
            XMLCatalog xmlCatalog = new XMLCatalog();
            var list = catalog.GetAllBooks();
            foreach (var book in list)
            {
                xmlCatalog.AddXMLBook(book.MapToXMLBook());
            }
            return xmlCatalog;
        }
    }
}
