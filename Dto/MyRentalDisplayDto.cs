namespace librarian.Dto
{
    public class MyRentalDisplayDto
    {
        public int RentalId { get; set; }
        public string BookTitle { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime PlannedReturnDate { get; set; }
    }
}
