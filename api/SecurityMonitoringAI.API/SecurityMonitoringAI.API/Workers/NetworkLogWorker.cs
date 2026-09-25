using Microsoft.EntityFrameworkCore;
using SecurityMonitoring.Api.Data;

namespace SecurityMonitoring.Api.Services;

public class NetworkLogWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly NetworkLogService _networkLogService;

    public NetworkLogWorker(
        IServiceScopeFactory scopeFactory,
        NetworkLogService networkLogService)
    {
        _scopeFactory = scopeFactory;
        _networkLogService = networkLogService;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var events =
                    _networkLogService.GetRecentNetworkEvents();

                using var scope = _scopeFactory.CreateScope();

                var context = scope.ServiceProvider
                    .GetRequiredService<SecurityMonitoringDbContext>();

                foreach (var securityEvent in events)
                {
                    bool alreadyExists =
                        await context.SecurityEvents.AnyAsync(
                            x =>
                                x.Timestamp == securityEvent.Timestamp &&
                                x.SourceIp == securityEvent.SourceIp &&
                                x.DestinationIp == securityEvent.DestinationIp &&
                                x.SourcePort == securityEvent.SourcePort &&
                                x.DestinationPort == securityEvent.DestinationPort &&
                                x.Protocol == securityEvent.Protocol,
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
                    $"Network Log Collector Error: {ex.Message}");
            }

            await Task.Delay(
                TimeSpan.FromSeconds(30),
                stoppingToken);
        }
    }
}