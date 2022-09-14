namespace fh_family_experience_infrastructure.Data;

using fh_family_experience_sharedkernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EfRepository<T> : IDisposable, IReadRepository<T> where T : class
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

    public Task<T> GetByServiceId(string serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByServiceLongAndLats(double longs, double lats)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetServiceDetails(string serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesByAddress(string postcode, string addressLine1, string city, string country)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesByLocation(string serviceId, string serviceOutCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesByLongAndLats(double longs, double lats)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesByOutCode(string serviceId, string serviceOutCode)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesByType(string serviceId, string serviceType)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetServicesWithAccessibility(string serviceId)
    {
        throw new NotImplementedException();
    }
}
