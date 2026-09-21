using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityMonitoring.Api.Data;
using SecurityMonitoring.Api.Models;

namespace SecurityMonitoring.Api.Controllers;

[ApiController]
[Route("api/incidents")]
public class IncidentsController : ControllerBase
{
    private readonly SecurityMonitoringDbContext _context;

    public IncidentsController(SecurityMonitoringDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var incidents = await _context.Incidents
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(incidents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var incident = await _context.Incidents
            .FindAsync(id);

        if (incident == null)
        {
            return NotFound();
        }

        return Ok(incident);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Incident incident)
    {
        incident.Id = 0;
        incident.CreatedAt = DateTime.UtcNow;
        incident.Status = "Open";

        _context.Incidents.Add(incident);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = incident.Id },
            incident
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Incident updatedIncident)
    {
        var incident = await _context.Incidents
            .FindAsync(id);

        if (incident == null)
        {
            return NotFound();
        }

        incident.Title = updatedIncident.Title;
        incident.Description = updatedIncident.Description;
        incident.Source = updatedIncident.Source;
        incident.RiskScore = updatedIncident.RiskScore;
        incident.Severity = updatedIncident.Severity;
        incident.Status = updatedIncident.Status;

        if (incident.Status == "Resolved" && incident.ResolvedAt == null)
        {
            incident.ResolvedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        return Ok(incident);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var incident = await _context.Incidents
            .FindAsync(id);

        if (incident == null)
        {
            return NotFound();
        }

        _context.Incidents.Remove(incident);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}