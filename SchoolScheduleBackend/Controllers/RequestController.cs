using Microsoft.AspNetCore.Mvc;
using SchoolScheduleBackend.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SchoolScheduleBackend.Dtos;
using SchoolScheduleBackend.DTOs;
using SchoolScheduleBackend.Models;

namespace SchoolScheduleBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly SchoolScheduleContext _context;

        public RequestsController(SchoolScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestDto>>> GetAll()
        {
            var requests = await _context.Request.ToListAsync();
            return requests.Select(r => ToDto(r)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDto>> GetById(int id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null) return NotFound();
            return ToDto(request);
        }

        [HttpPost]
        public async Task<ActionResult<RequestDto>> Create(RequestDto dto)
        {
            var request = new Request
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Status = dto.Status,
                SchedulePhotosJson = dto.SchedulePhotos != null
                    ? JsonSerializer.Serialize(dto.SchedulePhotos)
                    : null
            };

            _context.Request.Add(request);
            await _context.SaveChangesAsync();

            dto.Id = request.Id;
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RequestDto dto)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null) return NotFound();

            request.Status = dto.Status;
            request.ReceiverId = dto.ReceiverId;
            request.SchedulePhotosJson = dto.SchedulePhotos != null
                ? JsonSerializer.Serialize(dto.SchedulePhotos)
                : null;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.Request.FindAsync(id);
            if (request == null) return NotFound();

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private static RequestDto ToDto(Request r)
        {
            return new RequestDto
            {
                Id = r.Id,
                SenderId = r.SenderId,
                ReceiverId = r.ReceiverId,
                Status = r.Status,
                SchedulePhotos = r.SchedulePhotosJson != null
                    ? JsonSerializer.Deserialize<string[]>(r.SchedulePhotosJson)
                    : null
            };
        }
    }
}
