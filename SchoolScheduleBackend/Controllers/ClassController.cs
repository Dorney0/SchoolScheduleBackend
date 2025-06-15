using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public ClassController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetAll()
    {
        return await _context.Classes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> Get(int id)
    {
        var classEntity = await _context.Classes.FindAsync(id);
        if (classEntity == null)
            return NotFound();
        return classEntity;
    }

    [HttpPost]
    public async Task<ActionResult<Class>> Create(Class classEntity)
    {
        _context.Classes.Add(classEntity);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = classEntity.Id }, classEntity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Class classEntity)
    {
        if (id != classEntity.Id)
            return BadRequest();

        _context.Entry(classEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var classEntity = await _context.Classes.FindAsync(id);
        if (classEntity == null)
            return NotFound();

        _context.Classes.Remove(classEntity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}