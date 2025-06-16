using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.Dtos;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public EmployeeController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        var employees = await _context.Employees.ToListAsync();

        var dtoList = employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FullName = e.FullName,
            Position = e.Position,
            Email = e.Email,
            Phone = e.Phone
        });

        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> Get(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound();

        var dto = new EmployeeDto
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Position = employee.Position,
            Email = employee.Email,
            Phone = employee.Phone
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(EmployeeCreateDto dto)
    {
        var employee = new Employee
        {
            FullName = dto.FullName,
            Position = dto.Position,
            Email = dto.Email,
            Phone = dto.Phone
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        var resultDto = new EmployeeDto
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Position = employee.Position,
            Email = employee.Email,
            Phone = employee.Phone
        };

        return CreatedAtAction(nameof(Get), new { id = employee.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeCreateDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound();

        employee.FullName = dto.FullName;
        employee.Position = dto.Position;
        employee.Email = dto.Email;
        employee.Phone = dto.Phone;

        await _context.SaveChangesAsync();
        return Ok("Update is successful");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return NotFound();

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return Ok("Delete is successful");
    }
}
