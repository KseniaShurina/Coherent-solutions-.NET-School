using System.Xml.Serialization;

namespace Task6.DAL.XMLEntities
{
    [XmlRoot("Catalog")]
    public class XMLCatalog
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<XMLBook> XMLBooks = new List<XMLBook>();

        // Constructor for serialization
        public XMLCatalog() { }

        internal void AddXMLBook(XMLBook xmlBook)
        {
            XMLBooks.Add(xmlBook);
        }
    }
}
