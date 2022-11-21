using fh_family_experience_web.Services.Postcodes.Model;

namespace fh_family_experience_web.Services.Postcodes
{
    public interface IPostcodeLookupService
    {
        Task<PostcodeIOResponse> GetPostcodeAsync(string postcode);
    }
}
