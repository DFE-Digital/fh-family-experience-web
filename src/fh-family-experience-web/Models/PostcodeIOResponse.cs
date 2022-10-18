namespace fh_family_experience_web.Models
{
    public static class PostcodeIOResultsCodeKeys
    {
        public const string LocalAuthorityCode = "admin_district";
    }

    public class PostcodeIOResponse
    {
        public string Status { get; set; } = null!;
        public PostcodeIOResult? Result { get; set; }

        public string GetLocalAuthorityCode()
        {
            if (Result != null && Result.Codes.ContainsKey(PostcodeIOResultsCodeKeys.LocalAuthorityCode))
                return Result.Codes[PostcodeIOResultsCodeKeys.LocalAuthorityCode];

            return string.Empty;
        }
    }

    public class PostcodeIOResult
    {
        public string? PostCode { get; set; }
        public Dictionary<string, string> Codes { get; set; } = new Dictionary<string, string>();
    }
}
