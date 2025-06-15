namespace SchoolScheduleBackend.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
    public class EmployeeCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}