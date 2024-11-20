using Task6.DAL.XMLEntities;

namespace Task6.DAL.Interfaces
{
    public interface IXMLRepository
    {
        public void Save(XMLCatalog catalog);
        public XMLCatalog Get();
    }
}
