using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class PreferenceController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public PreferenceController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Preference>>> GetAll()
    {
        return await _context.Preferences.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Preference>> Get(int id)
    {
        var preference = await _context.Preferences.FindAsync(id);
        if (preference == null)
            return NotFound();
        return preference;
    }

    [HttpPost]
    public async Task<ActionResult<Preference>> Create(Preference preference)
    {
        _context.Preferences.Add(preference);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = preference.Id }, preference);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Preference preference)
    {
        if (id != preference.Id)
            return BadRequest();

        _context.Entry(preference).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var preference = await _context.Preferences.FindAsync(id);
        if (preference == null)
            return NotFound();

        _context.Preferences.Remove(preference);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}