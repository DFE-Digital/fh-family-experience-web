using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.Postcodes;

namespace fh_family_experience_web.Services.Api
{
    public interface IServiceDirectoryApiClient
    {
        Task<PostcodeIOResponseDto> GetPostcodeAsync(string postcode);

        Task<IList<OpenReferralServiceDto>> GetFamilyHubsForLocalAuthorityAsync(string postcode, string localAuthorityCode, double longtitude, double latitude);
    }
}
