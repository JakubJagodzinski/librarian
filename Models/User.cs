public class User
{
    public int AppUserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int ForeignKeyId { get; set; }
    public string UserType { get; set; } = string.Empty;
}