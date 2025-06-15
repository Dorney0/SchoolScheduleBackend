namespace SchoolScheduleBackend.Models;

public class Cabinet : BaseEntity
{
    public string Number { get; set; } = string.Empty;
    public int Capacity { get; set; }

    public ICollection<SubjectCabinet> SubjectCabinets { get; set; } = new List<SubjectCabinet>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Curriculum> Curricula { get; set; } = new List<Curriculum>();
}