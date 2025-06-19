namespace SchoolScheduleBackend.Dtos
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Status { get; set; } = "Новая";
        public string[]? SchedulePhotos { get; set; }
    }

    public class RequestCreateDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Status { get; set; } = "Новая";
        public string[]? SchedulePhotos { get; set; }
    }
}