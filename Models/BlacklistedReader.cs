namespace librarian.Models
{
    public class BlacklistedReader
    {
        public int BlacklistedReaderId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }

        public string Reason { get; set; } = string.Empty;
        public DateTime BlacklistedDate { get; set; }
        public DateTime? RemovalDate { get; set; }
    }
}
