namespace SchoolScheduleBackend.Models;

public class Employee : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
    public ICollection<SubjectEmployee> SubjectEmployees { get; set; } = new List<SubjectEmployee>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<ChangeLog> ChangeLogs { get; set; } = new List<ChangeLog>();
}