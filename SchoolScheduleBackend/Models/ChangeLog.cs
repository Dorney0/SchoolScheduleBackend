using SchoolScheduleBackend.Models;

public class ChangeLog : BaseEntity
{
    public int EmployeeId { get; set; }
    public string Entity { get; set; } = string.Empty;
    public string ChangeType { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public DateTime ChangeDate { get; set; }

    public Employee Employee { get; set; } = null!;
}
