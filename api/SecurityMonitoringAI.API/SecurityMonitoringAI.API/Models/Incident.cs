namespace SecurityMonitoring.Api.Models;

public class Incident
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public int RiskScore { get; set; }

    public string Severity { get; set; } = string.Empty;

    public string Status { get; set; } = "Open";

    public DateTime CreatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }
}