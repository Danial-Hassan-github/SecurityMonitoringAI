using System.Diagnostics;
using SecurityMonitoring.Api.Models;

namespace SecurityMonitoring.Api.Services;

public class WindowsEventLogService
{
    public List<SecurityEvent> GetRecentSecurityEvents()
    {
        var securityLog = new EventLog("Security");

        var events = new List<SecurityEvent>();

        int startIndex = Math.Max(0, securityLog.Entries.Count - 100);

        for (int i = startIndex; i < securityLog.Entries.Count; i++)
        {
            EventLogEntry entry = securityLog.Entries[i];

            long eventId = entry.InstanceId;

            if (eventId != 4624 &&
                eventId != 4625 &&
                eventId != 4648)
            {
                continue;
            }

            events.Add(new SecurityEvent
            {
                Timestamp = entry.TimeGenerated.ToUniversalTime(),
                SourceType = "WindowsEventLog",
                EventId = (int)eventId,
                EventType = GetEventType(eventId),
                Severity = GetSeverity(eventId),
                Message = entry.Message,
                Status = "New"
            });
        }

        return events;
    }

    private string GetEventType(long eventId)
    {
        return eventId switch
        {
            4624 => "Successful Logon",
            4625 => "Failed Logon",
            4648 => "Explicit Credential Logon",
            _ => "Windows Security Event"
        };
    }

    private string GetSeverity(long eventId)
    {
        return eventId switch
        {
            4625 => "High",
            4648 => "Medium",
            4624 => "Low",
            _ => "Low"
        };
    }
}