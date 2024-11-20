using Task6.BL.Extensions.Entities;
using Task6.BL.Interfaces;
using Task6.DAL.Entities;
using Task6.DAL.Extensions;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories;

namespace Task6.BL.Services
{
    internal class CatalogService : ICatalogService
    {
        private readonly IXMLRepository _xmlRepository;
        private readonly IJSONRepository _jsonRepository;

        public CatalogService()
        {
            _xmlRepository = new XMLRepository();
            _jsonRepository = new JSONRepository();
        }

        public void SaveCatalog(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new NullReferenceException();
            }

            _xmlRepository.Save(catalog.MapToXMLCatalog());
        }
        //TODO Check identity to initial object.
        public Catalog GetCatalog()
        {
            var catalog = _xmlRepository.Get().MapToCatalog();
            return catalog;
        }
    }
}
