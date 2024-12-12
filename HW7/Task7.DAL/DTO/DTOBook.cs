namespace Task7.DAL.DTO;

public class DTOBook
{
    public string Title { get; set; }
    public List<string> Identifiers { get; set; }
    public List<DTOAuthor> Authors { get; set; }

    public DTOBook() { }
}
