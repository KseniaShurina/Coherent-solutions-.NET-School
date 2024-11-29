using Task6.DAL.Entities;

namespace Task6.BL.Interfaces;

public interface ICatalogService
{
    public void SaveCatalogToXML(Catalog catalog);
    public Catalog? GetCatalogFromXML();

    public void SaveCatalogToJSON(Catalog catalog);
    public Catalog? GetCatalogFromJSON();
}