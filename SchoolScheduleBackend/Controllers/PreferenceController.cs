using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.Dtos;

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
    public async Task<ActionResult<IEnumerable<PreferenceDto>>> GetAll()
    {
        var preferences = await _context.Preferences.ToListAsync();

        var dtoList = preferences.Select(p => new PreferenceDto
        {
            Id = p.Id,
            EmployeeId = p.EmployeeId,
            Time = p.Time,
            Notes = p.Notes
        });

        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PreferenceDto>> Get(int id)
    {
        var preference = await _context.Preferences.FindAsync(id);
        if (preference == null)
            return NotFound();

        var dto = new PreferenceDto
        {
            Id = preference.Id,
            EmployeeId = preference.EmployeeId,
            Time = preference.Time,
            Notes = preference.Notes
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<PreferenceDto>> Create(PreferenceCreateDto dto)
    {
        var preference = new Preference
        {
            EmployeeId = dto.EmployeeId,
            Time = dto.Time,
            Notes = dto.Notes
        };

        _context.Preferences.Add(preference);
        await _context.SaveChangesAsync();

        var resultDto = new PreferenceDto
        {
            Id = preference.Id,
            EmployeeId = preference.EmployeeId,
            Time = preference.Time,
            Notes = preference.Notes
        };

        return CreatedAtAction(nameof(Get), new { id = preference.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PreferenceCreateDto dto)
    {
        var preference = await _context.Preferences.FindAsync(id);
        if (preference == null)
            return NotFound();

        preference.EmployeeId = dto.EmployeeId;
        preference.Time = dto.Time;
        preference.Notes = dto.Notes;

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
