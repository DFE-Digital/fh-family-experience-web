namespace fh_family_experience_api.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface IRepository
{
    public Task<List<Organisation>> GetOrganisationsAsync();
}
