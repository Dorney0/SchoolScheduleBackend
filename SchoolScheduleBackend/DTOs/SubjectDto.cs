﻿namespace SchoolScheduleBackend.DTOs
{
    public class SubjectCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
    public class SubjectReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}