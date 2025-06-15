namespace SchoolScheduleBackend.Models;

public class Class : BaseEntity
{
    public int EmployeeId { get; set; }

    public required string Name { get; set; }

    public int StudentCount { get; set; }

    public Employee? Employee { get; set; }

    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}