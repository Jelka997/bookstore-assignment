namespace BookstoreApplication.DTOs
{
    public class BookSearchDto
    {
        public string? Title { get; set; }
        public DateTime? PublishedFrom { get; set; }
        public DateTime? PublishedTo { get; set; }
        public int? AuthorId { get; set; } 
        public string? AuthorName { get; set; }
        public DateTime? AuthorBirthDateFrom { get; set; }
        public DateTime? AuthorBirthDateTo { get; set; }

    }
}
