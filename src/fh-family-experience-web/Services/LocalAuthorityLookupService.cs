using fh_family_experience_web.ViewModels;

namespace fh_family_experience_web.Services
{
    public class LocalAuthorityLookupService : ILocalAuthorityLookupService
    {
        private readonly ILocalAuthorityCache _localAuthorityCache;

        public LocalAuthorityLookupService(ILocalAuthorityCache localAuthorityCache)
        {
            _localAuthorityCache = localAuthorityCache;
        }

        public LocalAuthorityViewModel GetLocalAuthorityFromCode(string localAuthorityCode)
        {
            if(string.IsNullOrWhiteSpace(localAuthorityCode))
                return null;

            var authorityName = _localAuthorityCache.GetLocalAuthority(localAuthorityCode);

            if (string.IsNullOrWhiteSpace(authorityName))
                return null;

            return new LocalAuthorityViewModel { AuthorityCode = localAuthorityCode, AuthorityName = authorityName };
        }
    }
}
