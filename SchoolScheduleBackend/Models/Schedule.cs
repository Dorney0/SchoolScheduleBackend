using SchoolScheduleBackend.Models;

public class Schedule : BaseEntity
{
    public int EmployeeId { get; set; }
    public int SubjectId { get; set; }
    public int CabinetId { get; set; }
    public int ClassId { get; set; }
    public DateTime Date { get; set; }
    public int LessonNumber { get; set; }
    public int DurationMinutes { get; set; }

    public Employee? Employee { get; set; }
    public Subject? Subject { get; set; }
    public Cabinet? Cabinet { get; set; }
    public Class? Class { get; set; }

}