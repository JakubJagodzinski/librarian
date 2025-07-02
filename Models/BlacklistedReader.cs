using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Models
{
    public class BlacklistedReader
    {
        public int BlacklistedReaderId { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; } = new Reader();

        public string Reason { get; set; } = string.Empty;
        public DateTime BlacklistedDate { get; set; }
        public DateTime? RemovalDate { get; set; }
    }
}
