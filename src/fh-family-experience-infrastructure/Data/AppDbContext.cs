namespace fh_family_experience_infrastructure.Data;

using fh_family_experience_sharedkernel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AccessibilityForDisabilities> AccessibilityForDisabilities => Set<AccessibilityForDisabilities>();
    public DbSet<HolidaySchedule> HolidaySchedule => Set<HolidaySchedule>();
    public DbSet<Location> Location => Set<Location>();
    public DbSet<Organisation> Organisation => Set<Organisation>();
    public DbSet<PhysicalAddress> PhysicalAddress => Set<PhysicalAddress>();
    public DbSet<RegularSchedule> RegularSchedule => Set<RegularSchedule>();
    public DbSet<ServiceAtLocation> ServiceAtLocation => Set<ServiceAtLocation>();
    public DbSet<ServiceItem> ServiceItem => Set<ServiceItem>();

    public DbSet<ServiceItem> ServiceItems => Set<ServiceItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
