using SchoolScheduleBackend.Models;

public class SubjectCabinet : BaseEntity
{
    public int SubjectId { get; set; }
    public int CabinetId { get; set; }

    public Subject? Subject { get; set; }
    public Cabinet? Cabinet { get; set; }

}