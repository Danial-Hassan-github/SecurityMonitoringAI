namespace SecurityMonitoring.Api.Models;

public class SecurityEvent
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string SourceType { get; set; } = string.Empty;

    public string SourceIp { get; set; } = string.Empty;

    public string? DestinationIp { get; set; }

    public int? SourcePort { get; set; }

    public int? DestinationPort { get; set; }

    public string? Protocol { get; set; }

    public int? EventId { get; set; }

    public string EventType { get; set; } = string.Empty;

    public string Severity { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string Status { get; set; } = "New";
}