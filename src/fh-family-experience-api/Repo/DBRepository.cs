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
                Id=Guid.NewGuid(),
                Description="Tower Hamlets",
                Email="Tower.Hamlets@gmail.com",
                Name="Tower Hamlets",
                LogoUrl="www.Tower_Hamlets.com",
                Logo="Tower_Hamlets.png",
                Url="www.Tower_Hamlets.com/badge",
                CreatedBy="Joesph Chickweed",
                CreatedDate=DateTime.UtcNow,
                LastUpdated=DateTime.UtcNow,
                LastUpdatedBy="Seth Nettles"
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

        List<Eligibility> eligibility = new()
        {
            new Eligibility
            {
                Id=Guid.NewGuid(),
                EligibilityTypes = EligibilityTypes.Family,
                LinkId = Guid.NewGuid().ToString(),
                MaximumAge = 21,
                MinimumAge = 5,
                CreatedBy="Joesph Chickweed",
                CreatedDate=DateTime.UtcNow,
                LastUpdated=DateTime.UtcNow,
                LastUpdatedBy="Seth Nettles"
            }
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
            Eligibilities = eligibility,
            ServiceTaxonomies = servicetaxonomies1
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
            Eligibilities = eligibility,
            ServiceTaxonomies = servicetaxonomies2
        };

        List<Review> reviews = new()
        {
            new Review
            {
                Id=Guid.NewGuid(),
                Description="Review description",
                Score="1",
                Title="Review Title",
                Widget="Widget, for widgets sake",
                Url="www.Tower_Hamlets.com/review",
                Date=DateTime.Now,
                CreatedBy="Joesph Chickweed",
                CreatedDate=DateTime.UtcNow,
                LastUpdated=DateTime.UtcNow,
                LastUpdatedBy="Seth Nettles",
                Service=services1
            }
        };

        organisations[0].Services.Add(services1);
        organisations[0].Services.Add(services2);

        organisations[0].Reviews.Add(reviews[0]);

        context.Organisations.AddRange(organisations);
        context.SaveChanges();
    }

    public async Task<List<Organisation>> GetOrganisationsAsync()
    {
        using var context = new ApiContext();
        var list = await context.Organisations
            .Include(p => p.Services!).ThenInclude(x => x.Eligibilities)
            .Include(p => p.Services!).ThenInclude(x => x.ServiceTaxonomies).ThenInclude(x => x.Taxonomy)
            .Include(p => p.Reviews)
            .ToListAsync();
        return list;
    }
}


//var entity = await _context.OpenReferralOrganisations
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Eligibilities)
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Contacts)
//         .ThenInclude(x => x.Phones)
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Languages)
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Service_areas)
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Service_at_locations)
//         .ThenInclude(x => x.Location)
//         .Include(x => x.Services!)
//         .ThenInclude(x => x.Service_taxonomys)
//         .ThenInclude(x => x.Taxonomy)
//         .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
