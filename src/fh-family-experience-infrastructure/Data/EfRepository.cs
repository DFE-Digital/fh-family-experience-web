namespace fh_family_experience_infrastructure.Data;

using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EfRepository : IDisposable, IReadRepository
{
    private readonly DbContext dbContext;

    public EfRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Dispose()
    {
        dbContext.Dispose();
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
}
