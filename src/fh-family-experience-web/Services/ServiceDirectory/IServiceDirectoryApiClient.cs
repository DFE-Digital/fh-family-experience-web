using FamilyHubs.ServiceDirectory.Shared.Models;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralLocations;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;

namespace fh_family_experience_web.Services.Api
{
    public interface IServiceDirectoryApiClient
    {
        Task<List<Either<OpenReferralServiceDto, OpenReferralLocationDto, double>>> GetFamilyHubsForLocalAuthorityAsync(string localAuthorityCode, double longtitude, double latitude);
    }
}
