namespace SchoolScheduleBackend.Models;

public class Subject : BaseEntity
{
    public required string Title { get; set; } 
    public string? Description { get; set; }

    public ICollection<SubjectEmployee> SubjectEmployees { get; set; } = new List<SubjectEmployee>();
    public ICollection<SubjectCabinet> SubjectCabinets { get; set; } = new List<SubjectCabinet>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Curriculum> Curricula { get; set; } = new List<Curriculum>();

}