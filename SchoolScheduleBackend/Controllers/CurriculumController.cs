using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class CurriculumController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public CurriculumController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Curriculum>>> GetAll()
    {
        return await _context.Curricula.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Curriculum>> Get(int id)
    {
        var curriculum = await _context.Curricula.FindAsync(id);
        if (curriculum == null)
            return NotFound();
        return curriculum;
    }

    [HttpPost]
    public async Task<ActionResult<Curriculum>> Create(Curriculum curriculum)
    {
        _context.Curricula.Add(curriculum);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = curriculum.Id }, curriculum);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Curriculum curriculum)
    {
        if (id != curriculum.Id)
            return BadRequest();

        _context.Entry(curriculum).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Curricula.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var curriculum = await _context.Curricula.FindAsync(id);
        if (curriculum == null)
            return NotFound();

        _context.Curricula.Remove(curriculum);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}