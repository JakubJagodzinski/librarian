using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarian.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
