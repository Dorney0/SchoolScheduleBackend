using SchoolScheduleBackend.Models;

public class Curriculum : BaseEntity
{
    public int SubjectId { get; set; }
    public int CabinetId { get; set; }
    public int HoursPerWeek { get; set; }

    public Subject? Subject { get; set; } 
    public Cabinet? Cabinet { get; set; }   
}