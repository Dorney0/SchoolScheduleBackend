using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ChangeLogController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public ChangeLogController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChangeLogDto>>> GetAll()
    {
        return await _context.ChangeLogs
            .Select(cl => new ChangeLogDto
            {
                Id = cl.Id,
                EmployeeId = cl.EmployeeId,
                Entity = cl.Entity,
                ChangeType = cl.ChangeType,
                Description = cl.Description,
                ChangeDate = cl.ChangeDate
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ChangeLogDto>> Get(int id)
    {
        var cl = await _context.ChangeLogs.FindAsync(id);
        if (cl == null)
            return NotFound();

        return new ChangeLogDto
        {
            Id = cl.Id,
            EmployeeId = cl.EmployeeId,
            Entity = cl.Entity,
            ChangeType = cl.ChangeType,
            Description = cl.Description,
            ChangeDate = cl.ChangeDate
        };
    }

    [HttpPost]
    public async Task<ActionResult<ChangeLogDto>> Create(ChangeLogCreateDto dto)
    {
        var changeLog = new ChangeLog
        {
            EmployeeId = dto.EmployeeId,
            Entity = dto.Entity,
            ChangeType = dto.ChangeType,
            Description = dto.Description,
            ChangeDate = dto.ChangeDate
        };

        _context.ChangeLogs.Add(changeLog);
        await _context.SaveChangesAsync();

        var resultDto = new ChangeLogDto
        {
            Id = changeLog.Id,
            EmployeeId = changeLog.EmployeeId,
            Entity = changeLog.Entity,
            ChangeType = changeLog.ChangeType,
            Description = changeLog.Description,
            ChangeDate = changeLog.ChangeDate
        };

        return CreatedAtAction(nameof(Get), new { id = changeLog.Id }, resultDto);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ChangeLogDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var existing = await _context.ChangeLogs.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.EmployeeId = dto.EmployeeId;
        existing.Entity = dto.Entity;
        existing.ChangeType = dto.ChangeType;
        existing.Description = dto.Description;
        existing.ChangeDate = dto.ChangeDate;

        await _context.SaveChangesAsync();

        return Ok("Update is successful");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var changeLog = await _context.ChangeLogs.FindAsync(id);
        if (changeLog == null)
            return NotFound();

        _context.ChangeLogs.Remove(changeLog);
        await _context.SaveChangesAsync();

        return Ok("Delete is successful");
    }
}
