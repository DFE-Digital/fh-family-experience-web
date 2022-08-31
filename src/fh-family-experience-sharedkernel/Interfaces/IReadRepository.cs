namespace fh_family_experience_sharedkernel.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface IReadRepository<T> where T : class
{
    public Task<T> GetByServiceId(string serviceId);
    public Task<T> GetByServiceLongAndLats(double longs, double lats);
    public Task<T> GetServiceDetails(string serviceId);
    public Task<List<T>> GetServicesByType(string serviceId, string serviceType);
    public Task<List<T>> GetServicesByOutCode(string serviceId, string serviceOutCode);
    public Task<List<T>> GetServicesByLocation(string serviceId, string serviceOutCode);
    public Task<List<T>> GetServicesByLongAndLats(double longs, double lats);
    public Task<List<T>> GetServicesByAddress(string postcode, string addressLine1, string city, string country);
    public Task<List<T>> GetServicesWithAccessibility(string serviceId);
}
