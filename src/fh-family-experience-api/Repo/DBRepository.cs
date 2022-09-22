namespace fh_family_experience_api.Repo;

using Autofac.Core;
using fh_family_experience_api.DataContext;
using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Enums;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Threading.Tasks;
using PhysicalAddress = fh_family_experience_sharedkernel.Entities.PhysicalAddress;
using Service = fh_family_experience_sharedkernel.Entities.Service;

public class DBRepository : IRepository
{
    public DBRepository()
    {
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

        foreach (var service in GenerateListOfServices())
        {
            organisations[0].Services.Add(service);
        }

        using var context = new ApiContext();

        context.Organisations.AddRange(organisations);
        context.SaveChanges();
    }

    public async Task<List<Organisation>> GetOrganisationsAsync()
    {
        using var context = new ApiContext();
        var list = await context.Organisations

            .Include(p => p.Services!).ThenInclude(x => x.ServiceTaxonomies).ThenInclude(x => x.Taxonomy)

            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.Location).ThenInclude(x => x.PhysicalAddresses)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.Location).ThenInclude(x => x.AccessibilityForDisabilities)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.HolidaySchedules)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceAtLocations).ThenInclude(x => x.RegularSchedules)

            .ToListAsync();

        return list;
    }

    private List<Location> GenerateListOfLocations()
    {
        List<Location> listOfLocations = new();
        Random rand = new();
        List<string> listOfPostocodes = new()
        {
            "LU6 1AD",
            "LU1 1BE",
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

        for (int i = 0; i < 20; i++)
        {
            Location location = new()
            {
                Id = Guid.NewGuid(),
                Name = $"#{i} The name of the location.",
                Description = $"#{i} A description of this location.",
                Latitude = rand.NextDouble(),
                Longitude = rand.NextDouble(),
                PhysicalAddresses = new List<PhysicalAddress>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Address1 = $"This is Address Line 1 for address {i}",
                        City = "The City",
                        StateProvince = "The state or province",
                        Postcode = listOfPostocodes[i],
                        Country = "Country",
                        CreatedBy = "Joesph Chickweed",
                        CreatedDate = DateTime.UtcNow,
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "Seth Nettles",
                    }
                },
                AccessibilityForDisabilities = new List<AccessibilityForDisabilities>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Accessibility = $"#{i} Description of assistance or infrastructure that facilitate access to clients with disabilities.",
                        CreatedBy = "Joesph Chickweed",
                        CreatedDate = DateTime.UtcNow,
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "Seth Nettles",
                    }
                },
                CreatedBy = "Joesph Chickweed",
                CreatedDate = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                LastUpdatedBy = "Seth Nettles",
            };

            listOfLocations.Add(location);
        }

        return listOfLocations;
    }

    private List<ServiceAtLocation> GenerateListOfServiceAtLocations()
    {
        List<ServiceAtLocation> listOfServiceAtLocation = new();
        List<Location> listOfLocations = GenerateListOfLocations();

        for (int i = 0; i < 20; i++)
        {
            ServiceAtLocation serviceAtLocation = new()
            {
                Id = Guid.NewGuid(),
                Location = listOfLocations[i],
                HolidaySchedules = new List<HolidaySchedule>()
                {
                    new()
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
                    }
                },
                RegularSchedules = new List<RegularSchedule>()
                {
                    new()
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
                    }
                }
            };

            listOfServiceAtLocation.Add(serviceAtLocation);
        }

        return listOfServiceAtLocation;
    }

    private List<Service> GenerateListOfServices()
    {
        List<Service> listOfServices = new();
        List<ServiceAtLocation> listOfServiceAtLocation = GenerateListOfServiceAtLocations();

        for (int i = 0; i < 20; i++)
        {
            Service service1 = new()
            {
                Id = Guid.NewGuid(),
                Email = "service1.email@gmail.com",
                Name = $"Name of the Service {i}",
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
                    new()
                    {
                        Id = Guid.NewGuid(),
                        LinkId = Guid.NewGuid().ToString(),
                        Taxonomy = new()
                            {
                                Id = Guid.NewGuid(),
                                //The name of this taxonomy term or category.
                                Name = $"Category{i}",
                                // If this is a child category in a hierarchical taxonomy, give the identifier of the parent category.
                                // For top-level categories, this should be left blank.
                                ParentId = String.Empty,
                                Vocabulary = "Open Eligibility",
                                CreatedBy = "Joesph Chickweed",
                                CreatedDate = DateTime.UtcNow,
                                LastUpdated = DateTime.UtcNow,
                                LastUpdatedBy = "Seth Nettles"
                            },

                        CreatedBy = "Joesph Chickweed",
                        CreatedDate = DateTime.UtcNow,
                        LastUpdated = DateTime.UtcNow,
                        LastUpdatedBy = "Seth Nettles"
                    }
                },
                ServiceAtLocations = new List<ServiceAtLocation>() { listOfServiceAtLocation[i] }
            };

            listOfServices.Add(service1);
        }
        return listOfServices;
    }
}