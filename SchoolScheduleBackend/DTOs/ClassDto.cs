namespace SchoolScheduleBackend.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StudentCount { get; set; }
    }
    public class ClassCreateDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StudentCount { get; set; }
    }
}