using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; } = new Reader();
        public int BookId { get; set; }
        public Book Book { get; set; } = new Book();
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
