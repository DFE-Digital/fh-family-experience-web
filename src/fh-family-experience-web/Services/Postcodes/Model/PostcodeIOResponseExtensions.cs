namespace fh_family_experience_web.Services.Postcodes.Model
{
    public static class PostcodeIOResponseExtensions
    {
        public static string GetLocalAuthorityCode(this PostcodeIOResult result)
        {
            if (result != null && result.Codes.ContainsKey(PostcodeIOResultsCodeKeys.LocalAuthorityCode))
                return result.Codes[PostcodeIOResultsCodeKeys.LocalAuthorityCode];

            return string.Empty;
        }
    }
}
