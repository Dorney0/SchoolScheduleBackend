using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.Dtos;

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
    public async Task<ActionResult<IEnumerable<ClassDto>>> GetAll()
    {
        var classes = await _context.Classes.ToListAsync();

        var dtoList = classes.Select(c => new ClassDto
        {
            Id = c.Id,
            EmployeeId = c.EmployeeId,
            Name = c.Name,
            StudentCount = c.StudentCount
        });

        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClassDto>> Get(int id)
    {
        var classEntity = await _context.Classes.FindAsync(id);
        if (classEntity == null)
            return NotFound();

        var dto = new ClassDto
        {
            Id = classEntity.Id,
            EmployeeId = classEntity.EmployeeId,
            Name = classEntity.Name,
            StudentCount = classEntity.StudentCount
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ClassDto>> Create(ClassCreateDto dto)
    {
        var classEntity = new Class
        {
            EmployeeId = dto.EmployeeId,
            Name = dto.Name,
            StudentCount = dto.StudentCount
        };

        _context.Classes.Add(classEntity);
        await _context.SaveChangesAsync();

        var resultDto = new ClassDto
        {
            Id = classEntity.Id,
            EmployeeId = classEntity.EmployeeId,
            Name = classEntity.Name,
            StudentCount = classEntity.StudentCount
        };

        return CreatedAtAction(nameof(Get), new { id = classEntity.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ClassCreateDto dto)
    {
        var classEntity = await _context.Classes.FindAsync(id);
        if (classEntity == null)
            return NotFound();

        classEntity.EmployeeId = dto.EmployeeId;
        classEntity.Name = dto.Name;
        classEntity.StudentCount = dto.StudentCount;

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
