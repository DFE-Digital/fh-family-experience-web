namespace fh_family_experience_core.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface ISearchService
{
    Task<List<ServiceItem>> GetNextItemAsync(int serviceId);
    Task<List<ServiceItem>> GetAllItemsAsync(int serviceId, string searchString);
}
