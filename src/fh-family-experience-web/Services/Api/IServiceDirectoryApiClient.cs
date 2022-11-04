using fh_family_experience_web.Data.Entities;
using fh_family_experience_web.Models;

namespace fh_family_experience_web.Services.Api
{
    public interface IServiceDirectoryApiClient
    {
        Task<PostcodeIOResponse> GetPostcodeAsync(string postcode);

        Task<IList<Service>> GetFamilyHubsForLocalAuthorityAsync(string postcode, string localAuthorityCode, double longtitude, double latitude);
    }
}
