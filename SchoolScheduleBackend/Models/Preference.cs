namespace SchoolScheduleBackend.Models;

public class Preference
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Time { get; set; }
    public string Notes { get; set; } = string.Empty; 

    public Employee? Employee { get; set; } 
}