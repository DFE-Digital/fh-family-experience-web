using fh_family_experience_web.Models;
using Newtonsoft.Json;

namespace fh_family_experience_web.Services
{
    public class PostcodeLookupService : IPostcodeLookupService
    {
        private readonly string _postcodeIOBaseAddress;
        private readonly IHttpClientFactory _httpClientFactory;

        public PostcodeLookupService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            const string key = "postcodeIO:baseAddress";
            var postcodeIOBaseAddress = configuration.GetValue<string>(key);
            if (string.IsNullOrWhiteSpace(postcodeIOBaseAddress))
                throw new ArgumentNullException(key);

            if (!Uri.IsWellFormedUriString(postcodeIOBaseAddress, UriKind.Absolute))
                throw new ArgumentException(key);

            _postcodeIOBaseAddress = postcodeIOBaseAddress;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PostcodeIOResponse> GetPostcodeAsync(string postcode)
        {
            //string url = $"https://api.postcodes.io/postcodes/{postcode}";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_postcodeIOBaseAddress);

            var queryResponse = await client.GetAsync(postcode);

            if (queryResponse.StatusCode != System.Net.HttpStatusCode.OK && queryResponse.StatusCode != System.Net.HttpStatusCode.NotFound)
                throw new Exception($"Failed to query API for postcode {postcode}. HTTP Staus Code = {queryResponse.StatusCode}");

            string content = await queryResponse.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

            var result = JsonConvert.DeserializeObject<PostcodeIOResponse>(content);

            return result;
        }
    }
}
