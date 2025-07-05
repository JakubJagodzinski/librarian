namespace librarian.Dto
{
    public class RentalHistoryDisplayDto
    {
        public int RentalId { get; set; }
        public string BookTitle { get; set; }
        public string RentalDate { get; set; }
        public string PlannedReturnDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
