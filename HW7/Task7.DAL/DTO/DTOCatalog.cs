namespace Task7.DAL.DTO;

public class DTOCatalog
{
    //[XmlArray("Books")]
    //[XmlArrayItem("Book")]
    public List<DTOBook> Books = new List<DTOBook>();

    // Constructor for serialization
    public DTOCatalog() { }
}
