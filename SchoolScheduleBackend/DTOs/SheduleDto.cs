namespace SchoolScheduleBackend.Dtos
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SubjectId { get; set; }
        public int CabinetId { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public int DurationMinutes { get; set; }

        public string? EmployeeName { get; set; }
        public string? SubjectName { get; set; }
        public string? CabinetName { get; set; }
        public string? ClassName { get; set; }
    }

    public class ScheduleCreateDto
    {
        public int EmployeeId { get; set; }
        public int SubjectId { get; set; }
        public int CabinetId { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public int DurationMinutes { get; set; }
    }
}