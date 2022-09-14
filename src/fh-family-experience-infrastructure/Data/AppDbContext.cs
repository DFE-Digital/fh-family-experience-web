namespace fh_family_experience_infrastructure.Data;

using fh_family_experience_sharedkernel.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public DbSet<AccessibilityForDisabilities>? AccessibilityForDisabilities => Set<AccessibilityForDisabilities>();
    public DbSet<Contact>? Contacts => Set<Contact>();
    public DbSet<CostOption>? CostOptions => Set<CostOption>();
    public DbSet<Eligibility>? Eligibilities => Set<Eligibility>();
    public DbSet<Funding>? Fundings => Set<Funding>();
    public DbSet<HolidaySchedule> HolidaySchedule => Set<HolidaySchedule>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<LinkTaxonomy> LinkTaxonomies => Set<LinkTaxonomy>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Organisation> Organisations => Set<Organisation>();
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<PhysicalAddress> PhysicalAddress => Set<PhysicalAddress>();
    public DbSet<RegularSchedule> RegularSchedules => Set<RegularSchedule>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<ServiceArea> ServiceAreas => Set<ServiceArea>();
    public DbSet<ServiceAtLocation> ServiceAtLocations => Set<ServiceAtLocation>();
    public DbSet<ServiceTaxonomy> ServiceTaxonomies => Set<ServiceTaxonomy>();
    public DbSet<Taxonomy> Taxononmies => Set<Taxonomy>();
}
