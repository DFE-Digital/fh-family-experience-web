using fh_family_experience_web.Models;

namespace fh_family_experience_web.Services
{
    public interface IPostcodeLookupService
    {
        Task<PostcodeIOResponse> GetPostcodeAsync(string postcode);
    }
}
