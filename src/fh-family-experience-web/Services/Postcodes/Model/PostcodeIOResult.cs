namespace fh_family_experience_web.Services.Postcodes.Model
{
    public class PostcodeIOResult
    {
        public string? PostCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public Dictionary<string, string> Codes { get; set; } = new Dictionary<string, string>();
    }
}
