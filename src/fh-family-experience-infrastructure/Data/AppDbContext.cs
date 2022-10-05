namespace fh_family_experience_infrastructure.Data;

using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<AccessibilityForDisabilities>? AccessibilityForDisabilities => Set<AccessibilityForDisabilities>();
    public DbSet<Contact>? Contacts => Set<Contact>();
    public DbSet<CostOption>? CostOptions => Set<CostOption>();
    public DbSet<Eligibility>? Eligibilities => Set<Eligibility>();
    public DbSet<Funding>? Fundings => Set<Funding>();
    public DbSet<HolidaySchedule> HolidaySchedules => Set<HolidaySchedule>();
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var orgs = AddOrgs(modelBuilder);
        AddServices(modelBuilder, orgs);

    }

    private List<Organisation> AddOrgs(ModelBuilder modelBuilder)
    {
        var orgs = new List<Organisation> {
            new Organisation
            {
                Id = Guid.NewGuid(),
                Description = "Tower Hamlets",
                Email = "Tower.Hamlets@gmail.com",
                Name = "Tower Hamlets",
                LogoUrl = "www.Tower_Hamlets.com",
                Logo = "Tower_Hamlets.png",
                Url = "www.Tower_Hamlets.com/badge",
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles"
            },
            new Organisation
            {
                Id = Guid.NewGuid(),
                Description = "Salford City Council",
                Email = "Salford@gmail.com",
                Name = "Salford",
                LogoUrl = "https://www.salford.gov.uk/assets/images/scc.png",
                Logo = "scc.png",
                Url = "https://www.salford.gov.uk/",
                CreatedBy = "Bob Mortimer",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Vic Reeves"
            }
        };

        modelBuilder.Entity<Organisation>().HasData(orgs[0]);
        modelBuilder.Entity<Organisation>().HasData(orgs[1]);

        AddServices(modelBuilder, orgs);

        return orgs;
    }

    private void AddServices(ModelBuilder modelBuilder, List<Organisation> organisations)
    {
        foreach (var service in GenerateListOfServices(modelBuilder))
        {
            //organisations[0].Services.Add(service);
            service.OrganisationId = organisations[0].Id;
            modelBuilder.Entity<Service>().HasData(service);
        }
    }

    private List<Service> GenerateListOfServices(ModelBuilder modelBuilder)
    {
        List<Service> listOfServices = new();
        List<ServiceAtLocation> listOfServiceAtLocation = GenerateListOfServiceAtLocations(modelBuilder);

        var taxonomies = new List<Taxonomy>() {
            new Taxonomy
            {
                Id = Guid.NewGuid(),
                Name = "Family Hub",
                ParentId = String.Empty,
                Vocabulary = "Open Eligibility",
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles"
            }
        };

        foreach (var t in taxonomies)
        {
            modelBuilder.Entity<Taxonomy>().HasData(t);
        }

        for (int i = 0; i < 3; i++)
        {
            Service service1 = new()
            {
                Id = Guid.NewGuid(),
                Email = "service1.email@gmail.com",
                Name = $"A Helpful Service {i}",
                Description = $"Description of the service {i}",
                Accreditations = $"Accreditations awarded to the service {i}",
                AssuredDate = DateTime.Now,
                AttendingAccess = AttendingAccess.Appointment,
                AttendingType = AttendingTypes.Online,
                DeliverableType = DeliverableTypes.Counselling,
                Status = ServiceStatus.Active,
                Url = $"www.Tower_Hamlets.com/service{i}",
                Fees = "£25.00",
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
                ServiceTaxonomies = new List<ServiceTaxonomy>()
                {

                },
                //ServiceAtLocations = new List<ServiceAtLocation>() { listOfServiceAtLocation[i] }
            };

            listOfServiceAtLocation[i].ServiceId = service1.Id;

            var serviceTaxonomy = new ServiceTaxonomy()
            {
                Id = Guid.NewGuid(),
                LinkId = Guid.NewGuid().ToString(),
                ServiceId = service1.Id,
                TaxonomyId = taxonomies[0].Id,
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles"
            };

            modelBuilder.Entity<ServiceTaxonomy>().HasData(serviceTaxonomy);

            listOfServices.Add(service1);
        }
        return listOfServices;
    }

    private List<ServiceAtLocation> GenerateListOfServiceAtLocations(ModelBuilder modelBuilder)
    {
        List<ServiceAtLocation> listOfServiceAtLocation = new();
        List<Location> listOfLocations = GenerateListOfLocations(modelBuilder);

        for (int i = 0; i < 20; i++)
        {
            ServiceAtLocation serviceAtLocation = new()
            {
                Id = Guid.NewGuid(),
                LocationId = listOfLocations[i].Id,
                //HolidaySchedules = new List<HolidaySchedule>()
                //{
                //    new()
                //    {
                //        Id = Guid.NewGuid(),
                //        Closed = false,
                //        OpensAt = DateTime.MinValue,
                //        ClosesAt = DateTime.MaxValue,
                //        SatrtDate = DateTime.Now.AddDays(-1),
                //        EndDate = DateTime.Now.AddDays(1),
                //        CreatedBy = "Joesph Chickweed",
                //        CreatedDate = DateTime.UtcNow,
                //        LastUpdated = DateTime.UtcNow,
                //        LastUpdatedBy = "Seth Nettles",
                //    }
                //},
                //RegularSchedules = new List<RegularSchedule>()
                //{
                //    new()
                //    {
                //        Id = Guid.NewGuid(),
                //        WeekDay = 1,
                //        OpensAt = DateTime.Now,
                //        ClosesAt = DateTime.Now,
                //        ValidFrom = DateTime.Now,
                //        ValidTo = DateTime.Now,
                //        DtStart = DateTime.Now,
                //        Frequency = FrequencyTypes.Weekly,
                //        Interval = 1,
                //        ByDay = "MO",
                //        ByMonthDay = 3,
                //        Description = "The 2nd Monday of every month from 8:00pm till 12:00pm",
                //        CreatedBy = "Joesph Chickweed",
                //        CreatedDate = DateTime.UtcNow,
                //        LastUpdated = DateTime.UtcNow,
                //        LastUpdatedBy = "Seth Nettles",
                //    }
                //}
            };

            listOfServiceAtLocation.Add(serviceAtLocation);

            modelBuilder.Entity<ServiceAtLocation>().HasData(serviceAtLocation);
        }

        return listOfServiceAtLocation;
    }

    private List<Location> GenerateListOfLocations(ModelBuilder modelBuilder)
    {
        List<string> listOfPostcodes = new()
        {
            "E1 4NL",
            "E1 7PT",
            "E1 2DP",
            "E1 3HS",
            "LU1 1BP",
            "LU1 1BB",
            "LU1 1BN",
            "LU1 1BU",
            "HP23 4QF",
            "LU1 1JN",
            "LU1 1JQ",
            "LU1 1JS",
            "LU1 1JW",
            "LU1 1JY",
            "LU1 1QG",
            "LU1 1QF",
            "LU1 1PY",
            "LU1 1PW",
            "LU1 1PT",
            "LU1 1PS",
            "LU1 1PQ",
            "LU4 9PD"
        };

        var physicalAddresses = new List<PhysicalAddress>();

        for (var i = 1; i <= 21; i++)
        {
            physicalAddresses.Add(new PhysicalAddress
            {
                Id = Guid.NewGuid(),
                Address1 = $"This is Address Line 1 for address {i}",
                City = "The City",
                StateProvince = "The state or province",
                Postcode = listOfPostcodes[i],
                Country = "Country",
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
            });
        }

        foreach (var addr in physicalAddresses)
        {
            modelBuilder.Entity<PhysicalAddress>().HasData(addr);
        }

        List<Location> listOfLocations = new();
        Random rand = new();

        for (int i = 1; i < 21; i++)
        {
            Location location = new()
            {
                Id = Guid.NewGuid(),
                Name = $"#{i} The name of the location.",
                Description = $"#{i} A description of this location.",
                Latitude = rand.NextDouble(),
                Longitude = rand.NextDouble(),
                //PhysicalAddresses = new List<PhysicalAddress>()
                //{
                //    physicalAddresses[i]
                //},
                //AccessibilityForDisabilities = new List<AccessibilityForDisabilities>()
                //{
                //    new()
                //    {
                //        Id = Guid.NewGuid(),
                //        Accessibility = $"#{i} Description of assistance or infrastructure that facilitate access to clients with disabilities.",
                //        CreatedBy = "Joesph Chickweed",
                //        CreatedDate = DateTime.UtcNow,
                //        LastUpdated = DateTime.UtcNow,
                //        LastUpdatedBy = "Seth Nettles",
                //    }
                //},
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
            };

            physicalAddresses[i].LocationId = location.Id;

            listOfLocations.Add(location);

            modelBuilder.Entity<Location>().HasData(location);
        }

        return listOfLocations;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();

        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }
}
