﻿namespace librarian.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime PlannedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
