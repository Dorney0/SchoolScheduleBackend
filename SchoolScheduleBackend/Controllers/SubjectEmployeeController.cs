using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
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
    public async Task<ActionResult<IEnumerable<SubjectEmployee>>> GetAll()
    {
        return await _context.SubjectEmployees.ToListAsync();
    }

    [HttpGet("{subjectId}/{employeeId}")]
    public async Task<ActionResult<SubjectEmployee>> Get(int subjectId, int employeeId)
    {
        var item = await _context.SubjectEmployees.FindAsync(subjectId, employeeId);
        if (item == null)
            return NotFound();
        return item;
    }

    [HttpPost]
    public async Task<ActionResult<SubjectEmployee>> Create(SubjectEmployee subjectEmployee)
    {
        _context.SubjectEmployees.Add(subjectEmployee);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { subjectId = subjectEmployee.SubjectId, employeeId = subjectEmployee.EmployeeId }, subjectEmployee);
    }

    [HttpDelete("{subjectId}/{employeeId}")]
    public async Task<IActionResult> Delete(int subjectId, int employeeId)
    {
        var item = await _context.SubjectEmployees.FindAsync(subjectId, employeeId);
        if (item == null)
            return NotFound();

        _context.SubjectEmployees.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}