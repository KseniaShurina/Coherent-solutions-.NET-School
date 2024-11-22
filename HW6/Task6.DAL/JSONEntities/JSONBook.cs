using System.Text.Json.Serialization;

namespace Task6.DAL.JSONEntities
{
    public class JSONBook
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Isbn")]
        public string Isbn { get; set; }

        [JsonPropertyName("PublicationDate")]
        public DateTime? PublicationDate { get; set; }

        [JsonPropertyName("Authors")]
        public List<JSONAuthor> Authors { get; set; }

        public JSONBook() { }

    }
}
