﻿namespace SchoolScheduleBackend.Dtos
{
    public class ChangeLogDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Entity { get; set; } = string.Empty;
        public string ChangeType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ChangeDate { get; set; }
    }
    public class ChangeLogCreateDto
    {
        public int EmployeeId { get; set; }
        public string Entity { get; set; } = string.Empty;
        public string ChangeType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}