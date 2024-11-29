using Task6.BL.Interfaces;
using Task6.DAL.Entities;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories;

namespace Task6.BL.Services
{
    internal class CatalogService : ICatalogService
    {
        private readonly IRepository _xmlRepository;
        private readonly IRepository _jsonRepository;

        public CatalogService()
        {
            _xmlRepository = new XMLRepository();
            _jsonRepository = new JSONRepository();
        }

        public void SaveCatalogToXML(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new NullReferenceException();
            }

            _xmlRepository.Save(catalog);
        }
        
        public Catalog? GetCatalogFromXML()
        {
            var catalog = _xmlRepository.Get();

            return catalog ?? null;
        }

        public void SaveCatalogToJSON(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new NullReferenceException();
            }

            _jsonRepository.Save(catalog);
        }

        public Catalog? GetCatalogFromJSON()
        {
            var catalog = _jsonRepository.Get();

            return catalog ?? null;
        }
    }
}
