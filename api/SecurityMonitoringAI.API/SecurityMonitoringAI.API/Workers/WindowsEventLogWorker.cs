using Microsoft.EntityFrameworkCore;
using SecurityMonitoring.Api.Data;

namespace SecurityMonitoring.Api.Services;

public class WindowsEventLogWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly WindowsEventLogService _eventLogService;

    public WindowsEventLogWorker(
        IServiceScopeFactory scopeFactory,
        WindowsEventLogService eventLogService)
    {
        _scopeFactory = scopeFactory;
        _eventLogService = eventLogService;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var events = _eventLogService.GetRecentSecurityEvents();

                using var scope = _scopeFactory.CreateScope();

                var context = scope.ServiceProvider
                    .GetRequiredService<SecurityMonitoringDbContext>();

                foreach (var securityEvent in events)
                {
                    bool alreadyExists = await context.SecurityEvents
                        .AnyAsync(
                            x => x.EventId == securityEvent.EventId &&
                                 x.Timestamp == securityEvent.Timestamp,
                            stoppingToken);

                    if (!alreadyExists)
                    {
                        context.SecurityEvents.Add(securityEvent);
                    }
                }

                await context.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Windows Event Collector Error: {ex.Message}");
            }

            await Task.Delay(
                TimeSpan.FromSeconds(30),
                stoppingToken);
        }
    }
}