using SecurityMonitoring.Api.Models;

namespace SecurityMonitoring.Api.Services;

public class NetworkLogService
{
    private const string LogFilePath =
        @"C:\Windows\System32\LogFiles\Firewall\pfirewall.log";

    public List<SecurityEvent> GetRecentNetworkEvents()
    {
        var events = new List<SecurityEvent>();

        if (!File.Exists(LogFilePath))
        {
            return events;
        }

        using var stream = new FileStream(
            LogFilePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite);

        using var reader = new StreamReader(stream);

        var lines = new List<string>();

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line) &&
                !line.StartsWith("#"))
            {
                lines.Add(line);
            }
        }

        foreach (var lineToParse in lines.TakeLast(100))
        {
            var parts = lineToParse.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 8)
            {
                continue;
            }

            var securityEvent = ParseLine(parts);

            if (securityEvent != null)
            {
                events.Add(securityEvent);
            }
        }

        return events;
    }

    private SecurityEvent? ParseLine(string[] parts)
    {
        /*
         * Windows Firewall format:
         *
         * date time action protocol src-ip dst-ip src-port dst-port size tcpflags tcpsyn tcpack tcpwin icmptype icmpcode info path
         */

        if (parts.Length < 8)
        {
            return null;
        }

        var date = parts[0];
        var time = parts[1];
        var action = parts[2];
        var protocol = parts[3];
        var sourceIp = parts[4];
        var destinationIp = parts[5];
        var sourcePort = parts[6];
        var destinationPort = parts[7];

        if (!DateTime.TryParse(
        $"{date} {time}",
        out var timestamp))
        {
            return null;
        }

        timestamp = DateTime.SpecifyKind(
            timestamp,
            DateTimeKind.Utc);

        int? parsedSourcePort = ParsePort(sourcePort);
        int? parsedDestinationPort = ParsePort(destinationPort);

        return new SecurityEvent
        {
            Timestamp = timestamp,
            SourceType = "WindowsFirewall",
            SourceIp = sourceIp,
            DestinationIp = destinationIp,
            SourcePort = parsedSourcePort,
            DestinationPort = parsedDestinationPort,
            Protocol = protocol,
            EventType = "Network Traffic",
            Severity = GetSeverity(action),
            Message =
                $"{action} {protocol} traffic from " +
                $"{sourceIp}:{sourcePort} to " +
                $"{destinationIp}:{destinationPort}",
            Status = "New"
        };
    }

    private int? ParsePort(string value)
    {
        return int.TryParse(value, out var port)
            ? port
            : null;
    }

    private string GetSeverity(string action)
    {
        return action.ToUpperInvariant() switch
        {
            "DROP" => "Medium",
            "REJECT" => "Medium",
            "ALLOW" => "Low",
            _ => "Low"
        };
    }
}