using Task6.DAL.Entities;

namespace Task6.BL.Interfaces;

public interface ICatalogService
{
    public void SaveCatalog(Catalog catalog);
    public Catalog GetCatalog();
}