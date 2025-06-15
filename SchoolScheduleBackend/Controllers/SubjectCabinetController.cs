using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Data;
using SchoolScheduleBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class SubjectCabinetController : ControllerBase
{
    private readonly SchoolScheduleContext _context;

    public SubjectCabinetController(SchoolScheduleContext context)
    {
        _context = context;
    }

    // GET: api/SubjectCabinet
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectCabinet>>> GetAll()
    {
        return await _context.SubjectCabinets.ToListAsync();
    }

    // GET: api/SubjectCabinet/{subjectId}/{cabinetId}
    [HttpGet("{subjectId}/{cabinetId}")]
    public async Task<ActionResult<SubjectCabinet>> Get(int subjectId, int cabinetId)
    {
        var entity = await _context.SubjectCabinets.FindAsync(subjectId, cabinetId);
        if (entity == null)
            return NotFound();
        return entity;
    }

    // POST: api/SubjectCabinet
    [HttpPost]
    public async Task<ActionResult<SubjectCabinet>> Create(SubjectCabinet entity)
    {
        _context.SubjectCabinets.Add(entity);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { subjectId = entity.SubjectId, cabinetId = entity.CabinetId }, entity);
    }

    // PUT: api/SubjectCabinet/{subjectId}/{cabinetId}
    [HttpPut("{subjectId}/{cabinetId}")]
    public async Task<IActionResult> Update(int subjectId, int cabinetId, SubjectCabinet entity)
    {
        if (subjectId != entity.SubjectId || cabinetId != entity.CabinetId)
            return BadRequest();

        _context.Entry(entity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SubjectCabinetExists(subjectId, cabinetId))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/SubjectCabinet/{subjectId}/{cabinetId}
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

    private bool SubjectCabinetExists(int subjectId, int cabinetId)
    {
        return _context.SubjectCabinets.Any(e => e.SubjectId == subjectId && e.CabinetId == cabinetId);
    }
}
