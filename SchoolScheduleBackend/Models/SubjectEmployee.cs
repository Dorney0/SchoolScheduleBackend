using SchoolScheduleBackend.Models;

public class SubjectEmployee : BaseEntity
{
    public int SubjectId { get; set; }
    public int EmployeeId { get; set; }

    public Subject? Subject { get; set; }
    public Employee? Employee { get; set; }

}