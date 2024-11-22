using System.Text.Json.Serialization;

namespace Task6.DAL.JSONEntities
{
    public class JSONAuthor
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("DateOfBirthday")]
        public DateTime? DateOfBirthday { get; set; }

        public JSONAuthor() { }
    }
}
