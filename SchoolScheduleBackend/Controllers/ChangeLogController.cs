using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

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
    public async Task<ActionResult<IEnumerable<ChangeLog>>> GetAll()
    {
        return await _context.ChangeLogs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ChangeLog>> Get(int id)
    {
        var changeLog = await _context.ChangeLogs.FindAsync(id);
        if (changeLog == null)
            return NotFound();

        return changeLog;
    }

    [HttpPost]
    public async Task<ActionResult<ChangeLog>> Create(ChangeLog changeLog)
    {
        _context.ChangeLogs.Add(changeLog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = changeLog.Id }, changeLog);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ChangeLog changeLog)
    {
        if (id != changeLog.Id)
            return BadRequest();

        _context.Entry(changeLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ChangeLogExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var changeLog = await _context.ChangeLogs.FindAsync(id);
        if (changeLog == null)
            return NotFound();

        _context.ChangeLogs.Remove(changeLog);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ChangeLogExists(int id)
    {
        return _context.ChangeLogs.Any(e => e.Id == id);
    }
}
