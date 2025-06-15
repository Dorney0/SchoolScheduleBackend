namespace SchoolScheduleBackend.DTOs
{
    public class SubjectEmployeeCreateDto
    {
        public int SubjectId { get; set; }
        public int EmployeeId { get; set; }
    }
    public class SubjectEmployeeReadDto
    {
        public int SubjectId { get; set; }
        public int EmployeeId { get; set; }
        
        public string? SubjectTitle { get; set; }
        public string? EmployeeFullName { get; set; }
    }
}