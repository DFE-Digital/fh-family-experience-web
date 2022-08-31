namespace fh_family_experience_code_first_database;

using fh_family_experience_sharedkernel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<AccessibilityForDisabilities>? AccessibilityForDisabilities { get; set; }
    public DbSet<HolidaySchedule> HolidaySchedule => Set<HolidaySchedule>();
    public DbSet<Location> Location => Set<Location>();
    public DbSet<Organisation> Organisation => Set<Organisation>();
    public DbSet<PhysicalAddress> PhysicalAddress => Set<PhysicalAddress>();
    public DbSet<RegularSchedule> RegularSchedule => Set<RegularSchedule>();
    public DbSet<ServiceAtLocation> ServiceAtLocation => Set<ServiceAtLocation>();
    public DbSet<ServiceItem> ServiceItem => Set<ServiceItem>();

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-J6PB0R59\\SQLEXPRESS;Database=CleanArchitecture;Trusted_Connection=True;MultipleActiveResultSets=true");
        base.OnConfiguring (optionsBuilder);
    }
}