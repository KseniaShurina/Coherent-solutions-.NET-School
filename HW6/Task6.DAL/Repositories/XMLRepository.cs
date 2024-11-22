using System.Xml.Serialization;
using Task6.DAL.Interfaces;
using Task6.DAL.XMLEntities;

namespace Task6.DAL.Repositories
{
    public class XMLRepository : IXMLRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW6\Files\XML files\catalog.xml";
        public XMLRepository() { }

        public void Save(XMLCatalog catalog)
        {

            if (catalog == null)
            {
                throw new ArgumentNullException(nameof(catalog));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(XMLCatalog));

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, catalog);
            }
        }

        public XMLCatalog? Get()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLCatalog));

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                XMLCatalog? catalog = serializer.Deserialize(file) as XMLCatalog;
                return catalog ?? null;
            }
        }
    }
}
