namespace SchoolScheduleBackend.Models
{
    public class User
    {
        public int Id { get; set; }  // Primary key
        public string FullName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;  // Хранить хеш пароля!
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = "teacher"; // admin, teacher, external и т.п.

        public Employee? Employee { get; set; }
    }
}