namespace fh_family_experience_api.Repo;

using fh_family_experience_api.DataContext;
using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class DBRepository : IRepository
{
    public DBRepository()
    {
        using var context = new ApiContext();
        List<Organisation> organisations = new()
        {
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
            }
        };

        Taxonomy taxonomy1 = new()
        {
            Id = Guid.NewGuid(),
            //The name of this taxonomy term or category.
            Name = "Category1",
            // If this is a child category in a hierarchical taxonomy, give the identifier of the parent category.
            // For top-level categories, this should be left blank.
            ParentId = String.Empty,
            Vocabulary = "Open Eligibility",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles"
        };
        Taxonomy taxonomy2 = new()
        {
            Id = Guid.NewGuid(),
            //The name of this taxonomy term or category.
            Name = "Category2",
            // If this is a child category in a hierarchical taxonomy, give the identifier of the parent category.
            // For top-level categories, this should be left blank.
            ParentId = String.Empty,
            Vocabulary = "Open Eligibility",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles"
        };

        List<ServiceTaxonomy> servicetaxonomies1 = new()
        {
            new()
            {
            Id = Guid.NewGuid(),
            LinkId = Guid.NewGuid().ToString(),
            Taxonomy = taxonomy1,
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles"
            }
        };
        List<ServiceTaxonomy> servicetaxonomies2 = new()
        {
            new()
            {
            Id = Guid.NewGuid(),
            LinkId = Guid.NewGuid().ToString(),
            Taxonomy = taxonomy2,
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles"
            }
        };

        List<Eligibility> eligibility1 = new()
        {
            new Eligibility
            {
                Id = Guid.NewGuid(),
                EligibilityTypes = EligibilityTypes.Family,
                LinkId = Guid.NewGuid().ToString(),
                MaximumAge = 21,
                MinimumAge = 5,
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
                Taxonomies= new List<Taxonomy>() { taxonomy1 }
            }
        };
        List<Eligibility> eligibility2 = new()
        {
            new Eligibility
            {
                Id = Guid.NewGuid(),
                EligibilityTypes = EligibilityTypes.Transgender,
                LinkId = Guid.NewGuid().ToString(),
                MaximumAge = 21,
                MinimumAge = 5,
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
                Taxonomies= new List<Taxonomy>() { taxonomy2 }
            }
        };

        PhysicalAddress physicalAddress1 = new()
        {
            Id = Guid.NewGuid(),
            Address1 = "This is Address Line 1 fro address 1",
            City = "The City",
            StateProvince = "The state or province",
            Postcode = "Postcode",
            Country = "Country",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };
        PhysicalAddress physicalAddress2 = new()
        {
            Id = Guid.NewGuid(),
            Address1 = "This is Address Line 1 for address 2",
            City = "The City",
            StateProvince = "The state or province",
            Postcode = "Postcode",
            Country = "Country",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        AccessibilityForDisabilities accessibilityForDisabilities1 = new()
        {
            Id = Guid.NewGuid(),
            Accessibility = "#1 Description of assistance or infrastructure that facilitate access to clients with disabilities.",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };
        AccessibilityForDisabilities accessibilityForDisabilities2 = new()
        {
            Id = Guid.NewGuid(),
            Accessibility = "#2 Description of assistance or infrastructure that facilitate access to clients with disabilities.",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        Location loaction1 = new()
        {
            Id = Guid.NewGuid(),
            Name = "#1 The name of the location.",
            Description = "#1 A description of this location.",
            Latitude = 25.39,
            Longitude = 54.09,
            PhysicalAddresses = new List<PhysicalAddress>() { physicalAddress1 },
            AccessibilityForDisabilities = new List<AccessibilityForDisabilities>() { accessibilityForDisabilities1 },
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };
        Location loaction2 = new()
        {
            Id = Guid.NewGuid(),
            Name = "#2 The name of the location.",
            Description = "#2 A description of this location.",
            Latitude = 25.39,
            Longitude = 54.09,
            PhysicalAddresses = new List<PhysicalAddress>() { physicalAddress2 },
            AccessibilityForDisabilities = new List<AccessibilityForDisabilities>() { accessibilityForDisabilities2 },
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        HolidaySchedule holidaySchedule1 = new()
        {
            Id = Guid.NewGuid(),
            Closed = false,
            OpensAt = DateTime.MinValue,
            ClosesAt = DateTime.MaxValue,
            SatrtDate = DateTime.Now.AddDays(-1),
            EndDate = DateTime.Now.AddDays(1),
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };
        HolidaySchedule holidaySchedule2 = new()
        {
            Id = Guid.NewGuid(),
            Closed = true,
            OpensAt = DateTime.MinValue,
            ClosesAt = DateTime.MaxValue,
            SatrtDate = DateTime.Now.AddDays(-1),
            EndDate = DateTime.Now.AddDays(1),
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        RegularSchedule regularSchedule1 = new()
        {
            Id = Guid.NewGuid(),
            WeekDay = 1,
            OpensAt = DateTime.Now,
            ClosesAt = DateTime.Now,
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.Now,
            DtStart = DateTime.Now,
            Frequency = FrequencyTypes.Weekly,
            Interval = 1,
            ByDay = "MO",
            ByMonthDay = 3,
            Description = "The 2nd Monday of every month from 8:00pm till 12:00pm",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };
        RegularSchedule regularSchedule2 = new()
        {
            Id = Guid.NewGuid(),
            WeekDay = 1,
            OpensAt = DateTime.Now,
            ClosesAt = DateTime.Now,
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.Now,
            DtStart = DateTime.Now,
            Frequency = FrequencyTypes.Weekly,
            Interval = 1,
            ByDay = "MO",
            ByMonthDay = 3,
            Description = "The 2nd Monday of every month from 8:00pm till 12:00pm",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        ServiceAtLocation serviceAtLocation1 = new()
        {
            Id = Guid.NewGuid(),
            Location = loaction1,
            HolidaySchedules = new List<HolidaySchedule>() { holidaySchedule1 },
            RegularSchedules = new List<RegularSchedule>() { regularSchedule1 },
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        ServiceAtLocation serviceAtLocation2 = new()
        {
            Id = Guid.NewGuid(),
            Location = loaction2,
            HolidaySchedules = new List<HolidaySchedule>() { holidaySchedule2 },
            RegularSchedules = new List<RegularSchedule>() { regularSchedule2 },
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
        };

        Service services1 = new()
        {
            Id = Guid.NewGuid(),
            Email = "service1.email@gmail.com",
            Name = "Name of the Service1",
            Description = "Description of the service1",
            Accreditations = "Accreditations awarded to the service1",
            AssuredDate = DateTime.Now,
            AttendingAccess = AttendingAccess.Appointment,
            AttendingType = AttendingTypes.Online,
            DeliverableType = DeliverableTypes.Counselling,
            Status = ServiceStatus.Active,
            Url = "www.Tower_Hamlets.com/service1",
            Fees = "£25.00",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
            Organisation = organisations[0],
            Eligibilities = eligibility1,
            ServiceTaxonomies = servicetaxonomies1,
            ServiceAtLocations = new List<ServiceAtLocation>() { serviceAtLocation1 }
        };
        Service services2 = new()
        {
            Id = Guid.NewGuid(),
            Email = "service2.email@gmail.com",
            Name = "Name of the Service2",
            Description = "Description of the service2",
            Accreditations = "Accreditations awarded to the service2",
            AssuredDate = DateTime.Now,
            AttendingAccess = AttendingAccess.Appointment,
            AttendingType = AttendingTypes.Online,
            DeliverableType = DeliverableTypes.Counselling,
            Status = ServiceStatus.Active,
            Url = "www.Tower_Hamlets.com/service2",
            Fees = "£35.00",
            CreatedBy = "Joesph Chickweed",
            CreatedDate = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow,
            LastUpdatedBy = "Seth Nettles",
            Organisation = organisations[0],
            Eligibilities = eligibility2,
            ServiceTaxonomies = servicetaxonomies2,
            ServiceAtLocations = new List<ServiceAtLocation>() { serviceAtLocation2 }
        };

        List<Review> reviews = new()
        {
            new Review
            {
                Id = Guid.NewGuid(),
                Description = "Review description for 1",
                Score = "1",
                Title = "Review Title",
                Widget = "Widget, for widgets sake",
                Url = "www.Tower_Hamlets.com/review",
                Date = DateTime.Now,
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
                Service = services1
            },
            new Review
            {
                Id = Guid.NewGuid(),
                Description = "Review description for 2",
                Score = "2",
                Title = "Review Title",
                Widget = "Widget, for widgets sake",
                Url = "www.Tower_Hamlets.com/review",
                Date = DateTime.Now,
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
                Service = services1
            }
        };

        //organisations[0].Reviews.Add(reviews[0]);
        //organisations[0].Reviews.Add(reviews[1]);

        organisations[0].Services.Add(services1);
        organisations[0].Services.Add(services2);

        context.Organisations.AddRange(organisations);
        context.SaveChanges();
    }

    public async Task<List<Organisation>> GetOrganisationsAsync()
    {
        using var context = new ApiContext();
        var list = await context.Organisations
            .Include(p => p.Services!).ThenInclude(x => x.Eligibilities)

            .Include(p => p.Services!).ThenInclude(x => x.ServiceTaxonomies).ThenInclude(x => x.Taxonomy)

            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.Location).ThenInclude(x => x.PhysicalAddresses)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.Location).ThenInclude(x => x.AccessibilityForDisabilities)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.HolidaySchedules)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.RegularSchedules)

            .Include(p => p.Reviews)
            .ToListAsync();

        return list;
    }
}