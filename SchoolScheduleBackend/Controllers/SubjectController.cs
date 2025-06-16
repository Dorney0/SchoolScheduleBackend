using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.DTOs;
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

    // GET: api/Subject
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectReadDto>>> GetAll()
    {
        var subjects = await _context.Subjects
            .Select(s => new SubjectReadDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            })
            .ToListAsync();

        return Ok(subjects);
    }

    // GET: api/Subject/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectReadDto>> Get(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return NotFound();

        return new SubjectReadDto
        {
            Id = subject.Id,
            Title = subject.Title,
            Description = subject.Description
        };
    }

    // POST: api/Subject
    [HttpPost]
    public async Task<ActionResult<SubjectReadDto>> Create(SubjectCreateDto dto)
    {
        var subject = new Subject
        {
            Title = dto.Title,
            Description = dto.Description
        };

        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();

        var result = new SubjectReadDto
        {
            Id = subject.Id,
            Title = subject.Title,
            Description = subject.Description
        };

        return CreatedAtAction(nameof(Get), new { id = subject.Id }, result);
    }

    // PUT: api/Subject/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SubjectCreateDto dto)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return NotFound();

        subject.Title = dto.Title;
        subject.Description = dto.Description;

        await _context.SaveChangesAsync();
        return Ok("Update is successful");
    }

    // DELETE: api/Subject/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return NotFound();

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return Ok("Delete is successful");
    }
}
