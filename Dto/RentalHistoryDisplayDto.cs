namespace librarian.Dto
{
    public class RentalHistoryDisplayDto
    {
        public int RentalId { get; set; }
        public string BookTitle { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime PlannedReturnDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
