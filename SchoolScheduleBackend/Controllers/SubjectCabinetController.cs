using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Dtos;

[ApiController]
[Route("api/[controller]")]
public class SubjectCabinetController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public SubjectCabinetController(SchoolScheduleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectCabinetReadDto>>> GetAll()
    {
        var entities = await _context.SubjectCabinets
            .Include(sc => sc.Subject)
            .Include(sc => sc.Cabinet)
            .ToListAsync();

        var result = entities.Select(sc => new SubjectCabinetReadDto
        {
            SubjectId = sc.SubjectId,
            SubjectTitle = sc.Subject?.Title,
            CabinetId = sc.CabinetId,
            CabinetNumber = sc.Cabinet?.Number
        }).ToList();

        return Ok(result);
    }


    [HttpGet("{subjectId}/{cabinetId}")]
    public async Task<ActionResult<SubjectCabinetReadDto>> Get(int subjectId, int cabinetId)
    {
        var sc = await _context.SubjectCabinets
            .Include(sc => sc.Subject)
            .Include(sc => sc.Cabinet)
            .FirstOrDefaultAsync(sc => sc.SubjectId == subjectId && sc.CabinetId == cabinetId);

        if (sc == null)
            return NotFound();

        var dto = new SubjectCabinetReadDto
        {
            SubjectId = sc.SubjectId,
            SubjectTitle = sc.Subject?.Title,
            CabinetId = sc.CabinetId,
            CabinetNumber = sc.Cabinet?.Number
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<SubjectCabinetReadDto>> Create(SubjectCabinetCreateDto dto)
    {
        var entity = new SubjectCabinet
        {
            SubjectId = dto.SubjectId,
            CabinetId = dto.CabinetId
        };

        _context.SubjectCabinets.Add(entity);
        await _context.SaveChangesAsync();

        var created = await _context.SubjectCabinets
            .Include(sc => sc.Subject)
            .Include(sc => sc.Cabinet)
            .FirstOrDefaultAsync(sc => sc.SubjectId == dto.SubjectId && sc.CabinetId == dto.CabinetId);

        var result = new SubjectCabinetReadDto
        {
            SubjectId = created?.SubjectId ?? dto.SubjectId,
            SubjectTitle = created?.Subject?.Title,
            CabinetId = created?.CabinetId ?? dto.CabinetId,
            CabinetNumber = created?.Cabinet?.Number
        };

        return CreatedAtAction(nameof(Get), new { subjectId = dto.SubjectId, cabinetId = dto.CabinetId }, result);
    }

    [HttpPut("{subjectId}/{cabinetId}")]
    public Task<IActionResult> Update(int subjectId, int cabinetId)
    {
        return Task.FromResult<IActionResult>(BadRequest("Обновление не поддерживается для связей SubjectCabinet."));
    }


    [HttpDelete("{subjectId}/{cabinetId}")]
    public async Task<IActionResult> Delete(int subjectId, int cabinetId)
    {
        var entity = await _context.SubjectCabinets.FindAsync(subjectId, cabinetId);
        if (entity == null)
            return NotFound();

        _context.SubjectCabinets.Remove(entity);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
