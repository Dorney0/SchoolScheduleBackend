namespace SchoolScheduleBackend.Models;

public class Preference : BaseEntity
{
    public int EmployeeId { get; set; }
    public DateTime Time { get; set; }
    public string Notes { get; set; } = string.Empty; 

    public Employee? Employee { get; set; } 
}