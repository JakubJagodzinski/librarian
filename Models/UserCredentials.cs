namespace librarian.Models
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? ReaderId { get; set; }
        public int? EmployeeId { get; set; }

        public Reader Reader { get; set; }
        public Employee Employee { get; set; }
    }
}
