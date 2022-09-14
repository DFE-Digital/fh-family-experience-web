namespace fh_family_experience_core.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface ISearchService
{
    Task<List<Service>> GetNextItemAsync(int serviceId);
    Task<List<Service>> GetAllItemsAsync(int serviceId, string searchString);
}
