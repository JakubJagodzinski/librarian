namespace librarian.Dto
{
    public class BookDisplayDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public int Pages { get; set; }
        public int InStock { get; set; }
    }
}
