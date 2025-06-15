using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

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
    public async Task<ActionResult<IEnumerable<Schedule>>> GetAll()
    {
        return await _context.Schedules.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Schedule>> Get(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null)
            return NotFound();
        return schedule;
    }

    [HttpPost]
    public async Task<ActionResult<Schedule>> Create(Schedule schedule)
    {
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = schedule.Id }, schedule);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Schedule schedule)
    {
        if (id != schedule.Id)
            return BadRequest();

        _context.Entry(schedule).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null)
            return NotFound();

        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}