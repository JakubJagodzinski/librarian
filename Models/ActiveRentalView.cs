namespace librarian.Models
{
    public class ActiveRentalView
    {
        public int RentalId { get; set; }
        public int ReaderId { get; set; }
        public string BookTitle { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime PlannedReturnDate { get; set; }
    }
}
