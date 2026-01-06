using System.Text.Json.Serialization;

namespace BookstoreApplication.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public List<AuthorAward>? AuthorAwards { get; set; }
    }
}
