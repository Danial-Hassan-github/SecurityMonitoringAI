using Microsoft.EntityFrameworkCore;
using SecurityMonitoring.Api.Models;

namespace SecurityMonitoring.Api.Data;

public class SecurityMonitoringDbContext : DbContext
{
    public SecurityMonitoringDbContext(
        DbContextOptions<SecurityMonitoringDbContext> options)
        : base(options)
    {
    }

    public DbSet<SecurityEvent> SecurityEvents => Set<SecurityEvent>();
}