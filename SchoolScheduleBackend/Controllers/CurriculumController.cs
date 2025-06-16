using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;
using SchoolScheduleBackend.Dtos;

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
    public async Task<ActionResult<IEnumerable<CurriculumDto>>> GetAll()
    {
        var curricula = await _context.Curricula.ToListAsync();

        var dtoList = curricula.Select(c => new CurriculumDto
        {
            Id = c.Id,
            SubjectId = c.SubjectId,
            CabinetId = c.CabinetId,
            HoursPerWeek = c.HoursPerWeek
        });

        return Ok(dtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CurriculumDto>> Get(int id)
    {
        var curriculum = await _context.Curricula.FindAsync(id);
        if (curriculum == null)
            return NotFound();

        var dto = new CurriculumDto
        {
            Id = curriculum.Id,
            SubjectId = curriculum.SubjectId,
            CabinetId = curriculum.CabinetId,
            HoursPerWeek = curriculum.HoursPerWeek
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CurriculumDto>> Create(CurriculumCreateDto dto)
    {
        var curriculum = new Curriculum
        {
            SubjectId = dto.SubjectId,
            CabinetId = dto.CabinetId,
            HoursPerWeek = dto.HoursPerWeek
        };

        _context.Curricula.Add(curriculum);
        await _context.SaveChangesAsync();

        var resultDto = new CurriculumDto
        {
            Id = curriculum.Id,
            SubjectId = curriculum.SubjectId,
            CabinetId = curriculum.CabinetId,
            HoursPerWeek = curriculum.HoursPerWeek
        };

        return CreatedAtAction(nameof(Get), new { id = curriculum.Id }, resultDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CurriculumCreateDto dto)
    {
        var curriculum = await _context.Curricula.FindAsync(id);
        if (curriculum == null)
            return NotFound();

        curriculum.SubjectId = dto.SubjectId;
        curriculum.CabinetId = dto.CabinetId;
        curriculum.HoursPerWeek = dto.HoursPerWeek;

        await _context.SaveChangesAsync();
        return Ok("Update is successful");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var curriculum = await _context.Curricula.FindAsync(id);
        if (curriculum == null)
            return NotFound();

        _context.Curricula.Remove(curriculum);
        await _context.SaveChangesAsync();

        return Ok("Delete is successful");
    }
}
