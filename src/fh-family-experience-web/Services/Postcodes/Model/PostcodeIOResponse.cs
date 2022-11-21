namespace fh_family_experience_web.Services.Postcodes.Model
{
    public class PostcodeIOResponse
    {
        public string Status { get; set; } = null!;
        public PostcodeIOResult? Result { get; set; } = new PostcodeIOResult();
    }
}
