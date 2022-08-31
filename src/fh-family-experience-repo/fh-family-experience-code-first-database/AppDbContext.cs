namespace fh_family_experience_code_first_database;

using fh_family_experience_sharedkernel.Entities;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("fh-family-experience")
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

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}