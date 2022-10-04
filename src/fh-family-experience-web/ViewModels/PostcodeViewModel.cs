namespace fh_family_experience_web.ViewModels;
using fh_family_experience_web.ViewModels.Interfaces;

public static class PostcodeResultsCodeKeys
{
    public const string LocalAuthorityCode = "admin_district";
}

public class PostcodeViewModel : IPostcodeViewModel
{
    public string Status { get; set; } = null!;
    public PostcodeResultViewModel? Result { get; set; }

    public string GetLocalAuthority()
    {
        if(Result != null && Result.Codes.ContainsKey(PostcodeResultsCodeKeys.LocalAuthorityCode))
            return Result.Codes[PostcodeResultsCodeKeys.LocalAuthorityCode];

        return string.Empty;
    }
}

public class PostcodeResultViewModel
{
    public string? PostCode { get; set; }
    public Dictionary<string, string> Codes { get; set; } = new Dictionary<string, string>();

}
