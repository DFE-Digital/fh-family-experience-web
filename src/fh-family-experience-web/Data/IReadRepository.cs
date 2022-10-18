namespace fh_family_experience_web.Data;

using fh_family_experience_web.Data.Entities;

public interface IReadRepository
{
    public Task<ServiceCategory> GetByServiceId(string serviceId);
    public Task<ServiceCategory> GetByServiceLongAndLats(double longs, double lats);
    public Task<ServiceCategory> GetServiceDetails(string serviceId);
    public Task<List<ServiceCategory>> GetServicesByType(string serviceId, string serviceType);
    public Task<List<ServiceCategory>> GetServicesByOutCode(string serviceId, string serviceOutCode);
    public Task<List<ServiceCategory>> GetServicesByLocation(string serviceId, string serviceOutCode);
    public Task<List<ServiceCategory>> GetServicesByLongAndLats(double longs, double lats);
    public Task<List<ServiceCategory>> GetServicesByAddress(string postcode, string addressLine1, string city, string country);
    public Task<List<ServiceCategory>> GetServicesWithAccessibility(string serviceId);
    public Task<List<Service>> GetFamilyHubsForLocalAuthority(string localAuthorityName);
}
