using System.Text.Json.Serialization;

namespace BookstoreApplication.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year {  get; set; }
        [JsonIgnore]
        public List<AuthorAward> ? AuthorAwards { get; set; }
    }
}
