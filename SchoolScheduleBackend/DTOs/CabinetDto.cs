namespace SchoolScheduleBackend.DTOs
{
    public class CabinetDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }

    public class CreateCabinetDto
    {
        public string Number { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}