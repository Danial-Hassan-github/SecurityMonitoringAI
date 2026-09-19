namespace SecurityMonitoring.Api.Models;

public class SecurityEvent
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string SourceIp { get; set; } = string.Empty;

    public string EventType { get; set; } = string.Empty;

    public string Severity { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string Status { get; set; } = "New";
}