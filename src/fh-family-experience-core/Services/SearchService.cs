namespace fh_family_experience_core.Services;

using fh_family_experience_core.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SearchService : ISearchService
{
    private readonly IReadRepository _repository;

    public SearchService(IReadRepository repository)
    {
        _repository = repository;
    }

    public Task<List<ServiceCategory>> GetAllItemsAsync(int serviceId, string searchString)
    {
        throw new NotImplementedException();
    }

    public Task<List<ServiceCategory>> GetNextItemAsync(int serviceId)
    {
        throw new NotImplementedException();
    }
}
