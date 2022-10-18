using fh_family_experience_web.ViewModels;

namespace fh_family_experience_web.Services
{
    public interface ILocalAuthorityLookupService
    {
        public LocalAuthorityViewModel GetLocalAuthorityFromCode(string localAuthorityCode);
    }
}
