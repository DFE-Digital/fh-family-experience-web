namespace fh_family_experience_api.Interfaces;

using fh_family_experience_sharedkernel.Entities;

public interface IRepository
{
    public List<Organisation> GetOrganisations();
}
