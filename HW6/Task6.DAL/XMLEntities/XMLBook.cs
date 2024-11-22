using System.Xml.Serialization;

namespace Task6.DAL.XMLEntities
{
    public class XMLBook
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Isbn")]
        public string Isbn { get; set; }

        [XmlElement("PublicationDate")]
        public DateTime? PublicationDate { get; set; }

        [XmlArray("Authors")]
        [XmlArrayItem("Author")]
        public List<XMLAuthor>? Authors { get; set; }

        public XMLBook() { }
    }
}
