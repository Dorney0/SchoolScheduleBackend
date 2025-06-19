using SchoolScheduleBackend.Models;
namespace SchoolScheduleBackend.Models;
public class Preference : BaseEntity
{
    public int UserId { get; set; } 

    public DateTime Time { get; set; }
    public string Notes { get; set; } = string.Empty;

    public User? User { get; set; }
}