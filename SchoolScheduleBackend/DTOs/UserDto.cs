namespace SchoolScheduleBackend.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = "teacher";
 
    }

    public class CreateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = "teacher";
 
    }
}