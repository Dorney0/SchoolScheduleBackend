namespace SchoolScheduleBackend.Models;
using System.ComponentModel.DataAnnotations;

public class Teacher
{
    [Key]
    public int Id { get; set; }

    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public ICollection<Preference> Preferences { get; set; } = new List<Preference>();
    public ICollection<SubjectEmployee> SubjectTeachers { get; set; } = new List<SubjectEmployee>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Class> Classes { get; set; } = new List<Class>();
}