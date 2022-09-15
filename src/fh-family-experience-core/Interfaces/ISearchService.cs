namespace fh_family_experience_core.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface ISearchService
{
    Task<List<ServiceCategory>> GetNextItemAsync(int serviceId);
    Task<List<ServiceCategory>> GetAllItemsAsync(int serviceId, string searchString);
}
