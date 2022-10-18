namespace fh_family_experience_web.Data;

using fh_family_experience_web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EfRepository : IDisposable, IReadRepository
{
    private readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public Task<ServiceCategory> GetByServiceId(string serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceCategory> GetByServiceLongAndLats(double longs, double lats)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceCategory> GetServiceDetails(string serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesByAddress(string postcode, string addressLine1, string city, string country)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesByLocation(string serviceId, string serviceOutCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesByLongAndLats(double longs, double lats)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesByOutCode(string serviceId, string serviceOutCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesByType(string serviceId, string serviceType)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetServicesWithAccessibility(string serviceId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Service>> GetFamilyHubsForLocalAuthority(string localAuthorityName)
    {
        if(string.IsNullOrWhiteSpace(localAuthorityName))
            return new List<Service>();

        var org = await _dbContext.Organisations
            .Include(o => o.Services)
                .ThenInclude(s => s.ServiceTaxonomies)
                .ThenInclude(st => st.Taxonomy)
            .Include(o => o.Services)
                .ThenInclude(s => s.ServiceAtLocations)
                .ThenInclude(sl => sl.Location)
                .ThenInclude(l => l.PhysicalAddresses)            
            .FirstOrDefaultAsync(o => string.Equals(o.Name, localAuthorityName, StringComparison.InvariantCultureIgnoreCase));

        if (org == null)
            return new List<Service>();

        var services = org.Services.Where(s => s.ServiceTaxonomies.Any(t => t.Taxonomy != null && t.Taxonomy.Name == "Family Hub")).ToList();

        return services;
    }
}
