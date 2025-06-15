using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.DTOs;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class SubjectEmployeeController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public SubjectEmployeeController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectEmployeeReadDto>>> GetAll()
    {
        var list = await _context.SubjectEmployees
            .Include(se => se.Subject)
            .Include(se => se.Employee)
            .Select(se => new SubjectEmployeeReadDto
            {
                SubjectId = se.SubjectId,
                EmployeeId = se.EmployeeId,
                SubjectTitle = se.Subject != null ? se.Subject.Title : null,
                EmployeeFullName = se.Employee != null ? se.Employee.FullName : null
            })
            .ToListAsync();

        return Ok(list);
    }

    [HttpGet("{subjectId}/{employeeId}")]
    public async Task<ActionResult<SubjectEmployeeReadDto>> Get(int subjectId, int employeeId)
    {
        var se = await _context.SubjectEmployees
            .Include(se => se.Subject)
            .Include(se => se.Employee)
            .FirstOrDefaultAsync(se => se.SubjectId == subjectId && se.EmployeeId == employeeId);

        if (se == null)
            return NotFound();

        return new SubjectEmployeeReadDto
        {
            SubjectId = se.SubjectId,
            EmployeeId = se.EmployeeId,
            SubjectTitle = se.Subject != null ? se.Subject.Title : null,
            EmployeeFullName = se.Employee != null ? se.Employee.FullName : null
        };
    }

    [HttpPost]
    public async Task<ActionResult<SubjectEmployeeReadDto>> Create(SubjectEmployeeCreateDto dto)
    {
        var entity = new SubjectEmployee
        {
            SubjectId = dto.SubjectId,
            EmployeeId = dto.EmployeeId
        };

        _context.SubjectEmployees.Add(entity);
        await _context.SaveChangesAsync();

        // Подгружаем навигационные свойства для возврата DTO
        await _context.Entry(entity).Reference(se => se.Subject).LoadAsync();
        await _context.Entry(entity).Reference(se => se.Employee).LoadAsync();

        var result = new SubjectEmployeeReadDto
        {
            SubjectId = entity.SubjectId,
            EmployeeId = entity.EmployeeId,
            SubjectTitle = entity.Subject != null ? entity.Subject.Title : null,
            EmployeeFullName = entity.Employee != null ? entity.Employee.FullName : null
        };

        return CreatedAtAction(nameof(Get), new { subjectId = result.SubjectId, employeeId = result.EmployeeId }, result);
    }

    [HttpDelete("{subjectId}/{employeeId}")]
    public async Task<IActionResult> Delete(int subjectId, int employeeId)
    {
        var entity = await _context.SubjectEmployees.FindAsync(subjectId, employeeId);
        if (entity == null)
            return NotFound();

        _context.SubjectEmployees.Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
