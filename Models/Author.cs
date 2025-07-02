using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace librarian.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFullName { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
