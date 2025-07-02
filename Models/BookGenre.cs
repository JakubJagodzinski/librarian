using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = new Book();

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = new Genre();
    }
}