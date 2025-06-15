namespace SchoolScheduleBackend.Dtos
{
    public class SubjectCabinetCreateDto
    {
        public int SubjectId { get; set; }
        public int CabinetId { get; set; }
    }

    public class SubjectCabinetReadDto
    {
        public int SubjectId { get; set; }
        public string? SubjectTitle { get; set; } = string.Empty;
        public int CabinetId { get; set; }
        public string? CabinetNumber { get; set; } = string.Empty;
    }
}