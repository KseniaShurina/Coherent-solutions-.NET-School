namespace Task6.DAL.DTO
{
    public class DTOBook
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<DTOAuthor> Authors { get; set; }

        public DTOBook() { }
    }
}
