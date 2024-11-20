using Task6.BL.Interfaces;
using Task6.DAL.Entities;
using Task6.DAL.Interfaces;
using Task6.DAL.Repository;

namespace Task6.BL.Services
{
    internal class CatalogService : ICatalogService
    {
        private readonly IRepository _repository;

        public CatalogService()
        {
            _repository = new XMLRepository();
        }

        public void SaveCatalog(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new NullReferenceException();
            }

            _repository.Save(catalog);
        }

        public Catalog GetCatalog()
        {
           return _repository.Get();
        }
    }
}
