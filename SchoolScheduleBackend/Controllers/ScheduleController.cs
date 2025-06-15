using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public ScheduleController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetAll()
    {
        var schedules = await _context.Schedules
            .Include(s => s.Employee)
            .Include(s => s.Subject)
            .Include(s => s.Cabinet)
            .Include(s => s.Class)
            .ToListAsync();

        var dtoList = schedules.Select(s => new ScheduleDto
        {
            Id = s.Id,
            EmployeeId = s.EmployeeId,
            SubjectId = s.SubjectId,
            CabinetId = s.CabinetId,
            ClassId = s.ClassId,
            Date = s.Date,
            LessonNumber = s.LessonNumber,
            DurationMinutes = s.DurationMinutes,

            EmployeeName = s.Employee?.FullName,
            SubjectName = s.Subject?.Title,
            CabinetName = s.Cabinet?.Number,
            ClassName = s.Class?.Name
        });

        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ScheduleDto>> Get(int id)
    {
        var s = await _context.Schedules
            .Include(s => s.Employee)
            .Include(s => s.Subject)
            .Include(s => s.Cabinet)
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (s == null) return NotFound();

        var dto = new ScheduleDto
        {
            Id = s.Id,
            EmployeeId = s.EmployeeId,
            SubjectId = s.SubjectId,
            CabinetId = s.CabinetId,
            ClassId = s.ClassId,
            Date = s.Date,
            LessonNumber = s.LessonNumber,
            DurationMinutes = s.DurationMinutes,

            EmployeeName = s.Employee?.FullName,
            SubjectName = s.Subject?.Title,
            CabinetName = s.Cabinet?.Number,
            ClassName = s.Class?.Name
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ScheduleDto>> Create(ScheduleCreateDto dto)
    {
        var schedule = new Schedule
        {
            EmployeeId = dto.EmployeeId,
            SubjectId = dto.SubjectId,
            CabinetId = dto.CabinetId,
            ClassId = dto.ClassId,
            Date = dto.Date,
            LessonNumber = dto.LessonNumber,
            DurationMinutes = dto.DurationMinutes
        };

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();

        // Возвращаем созданный объект с данными (без навигационных свойств)
        var resultDto = new ScheduleDto
        {
            Id = schedule.Id,
            EmployeeId = schedule.EmployeeId,
            SubjectId = schedule.SubjectId,
            CabinetId = schedule.CabinetId,
            ClassId = schedule.ClassId,
            Date = schedule.Date,
            LessonNumber = schedule.LessonNumber,
            DurationMinutes = schedule.DurationMinutes
        };

        return CreatedAtAction(nameof(Get), new { id = schedule.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ScheduleCreateDto dto)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null) return NotFound();

        schedule.EmployeeId = dto.EmployeeId;
        schedule.SubjectId = dto.SubjectId;
        schedule.CabinetId = dto.CabinetId;
        schedule.ClassId = dto.ClassId;
        schedule.Date = dto.Date;
        schedule.LessonNumber = dto.LessonNumber;
        schedule.DurationMinutes = dto.DurationMinutes;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null) return NotFound();

        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
