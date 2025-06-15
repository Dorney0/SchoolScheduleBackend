using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.DTOs;

[ApiController]
[Route("api/[controller]")]
public class CabinetController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public CabinetController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CabinetDto>>> GetAll()
    {
        return await _context.Cabinets
            .Select(c => new CabinetDto
            {
                Id = c.Id,
                Number = c.Number,
                Capacity = c.Capacity
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CabinetDto>> Get(int id)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);
        if (cabinet == null)
            return NotFound();

        var dto = new CabinetDto
        {
            Id = cabinet.Id,
            Number = cabinet.Number,
            Capacity = cabinet.Capacity
        };

        return dto;
    }

    [HttpPost]
    public async Task<ActionResult<CabinetDto>> Create(CreateCabinetDto dto)
    {
        var cabinet = new Cabinet
        {
            Number = dto.Number,
            Capacity = dto.Capacity
        };

        _context.Cabinets.Add(cabinet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = cabinet.Id }, new CabinetDto
        {
            Id = cabinet.Id,
            Number = cabinet.Number,
            Capacity = cabinet.Capacity
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateCabinetDto dto)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);
        if (cabinet == null)
            return NotFound();

        cabinet.Number = dto.Number;
        cabinet.Capacity = dto.Capacity;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cabinet = await _context.Cabinets.FindAsync(id);
        if (cabinet == null)
            return NotFound();

        _context.Cabinets.Remove(cabinet);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
