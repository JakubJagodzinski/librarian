using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = new Author();
        public int PublishedYear { get; set; }
        public int Pages { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
