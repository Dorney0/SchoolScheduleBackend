namespace SchoolScheduleBackend.Models
{
    public class User
    {
        public int Id { get; set; }  
        public string FullName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;  
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; } = "teacher"; 
        public Employee? Employee { get; set; }
        public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
    }
}