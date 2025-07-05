namespace librarian.Dto
{
    public class BlacklistedReaderDisplayDto
    {
        public int BlacklistedReaderId { get; set; }
        public string ReaderName { get; set; }
        public string Reason { get; set; }
        public string BlacklistedDate { get; set; }
        public string RemovalDate { get; set; }
    }
}