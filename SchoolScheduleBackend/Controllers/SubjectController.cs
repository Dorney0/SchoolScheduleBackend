using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public SubjectController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
    {
        return await _context.Subjects.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> Get(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return NotFound();
        return subject;
    }

    [HttpPost]
    public async Task<ActionResult<Subject>> Create(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = subject.Id }, subject);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Subject subject)
    {
        if (id != subject.Id)
            return BadRequest();

        _context.Entry(subject).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return NotFound();

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}