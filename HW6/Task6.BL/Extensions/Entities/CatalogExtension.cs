using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.BL.Extensions.Entities
{
    internal static class CatalogExtension
    {
        internal static Catalog MapToCatalog(this XMLCatalog xmlCatalog)
        {
            Catalog catalog = new Catalog();
            foreach (var xmlBook in xmlCatalog.XMLBooks)
            {
                catalog.AddBook(xmlBook.MapToBook());
            }
            return catalog;
        }
    }
}
