using System.Text.Json.Serialization;

namespace librarian.Models
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
