using System.Xml.Serialization;

namespace Task6.DAL.XMLEntities
{
    public class XMLAuthor
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("DateOfBirth")]
        public DateTime? DateOfBirthday { get; set; }

        public XMLAuthor(){}
    }
}
