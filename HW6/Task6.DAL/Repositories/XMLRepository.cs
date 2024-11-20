using System.Xml.Serialization;
using Task6.DAL.Entities;
using Task6.DAL.Interfaces;

namespace Task6.DAL.Repository
{
    public class XMLRepository : IRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW6\catalog.xml";
        public XMLRepository() { }

        public void Save(Catalog catalog)
        {

            if (catalog == null)
            {
                throw new ArgumentNullException(nameof(catalog));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, catalog);
            }
        }

        public Catalog? Get()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                Catalog? catalog = serializer.Deserialize(file) as Catalog;
                return catalog ?? null;
            }
            
            //throw new NotImplementedException();
        }
        public void Update() { }
        public void Delete() { }
        public void DeleteAll() { }
    }
}
