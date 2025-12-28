namespace Books.Api.Models
{
    public class BookWithAuthor
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
    }

}