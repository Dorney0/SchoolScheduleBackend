namespace SchoolScheduleBackend.Dtos
{
    public class PreferenceDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
    public class PreferenceCreateDto
    {
        public int EmployeeId { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}