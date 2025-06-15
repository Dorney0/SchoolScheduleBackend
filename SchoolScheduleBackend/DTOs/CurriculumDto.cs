namespace SchoolScheduleBackend.Dtos
{
    public class CurriculumDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int CabinetId { get; set; }
        public int HoursPerWeek { get; set; }
    }
    public class CurriculumCreateDto
    {
        public int SubjectId { get; set; }
        public int CabinetId { get; set; }
        public int HoursPerWeek { get; set; }
    }
}