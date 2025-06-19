namespace SchoolScheduleBackend.Models
{
    public class Request : BaseEntity
    {
        public int Id { get; set; }
        
        public int SenderId { get; set; }
        
        public int ReceiverId { get; set; }

        public string Status { get; set; } = "new";
        
        public string? SchedulePhotosJson { get; set; }

        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!;
    }
}