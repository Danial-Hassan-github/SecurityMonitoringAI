using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityMonitoring.Api.Data;
using SecurityMonitoring.Api.Models;

namespace SecurityMonitoring.Api.Controllers;

[ApiController]
[Route("api/security-events")]
public class SecurityEventsController : ControllerBase
{
    private readonly SecurityMonitoringDbContext _context;

    public SecurityEventsController(SecurityMonitoringDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _context.SecurityEvents
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync();

        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var securityEvent = await _context.SecurityEvents
            .FindAsync(id);

        if (securityEvent == null)
        {
            return NotFound();
        }

        return Ok(securityEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SecurityEvent securityEvent)
    {
        securityEvent.Id = 0;
        securityEvent.Timestamp = DateTime.UtcNow;
        securityEvent.Status = "New";

        _context.SecurityEvents.Add(securityEvent);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = securityEvent.Id },
            securityEvent
        );
    }
}