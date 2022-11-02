using fh_family_experience_web.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace fh_family_experience_web.Services.Api
{
    public class ServiceDirectoryApiClient : IServiceDirectoryApiClient
    {
        private readonly ILogger<ServiceDirectoryApiClient> _logger;
        private readonly HttpClient _client;

        public ServiceDirectoryApiClient(ILogger<ServiceDirectoryApiClient> logger, HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _logger = logger;

            const string key = "serviceDirectoryApi:baseAddress";

            var serviceDirectoryApiBaseAddress = configuration.GetValue<string>(key);
            
            if (string.IsNullOrWhiteSpace(serviceDirectoryApiBaseAddress))
                throw new ArgumentNullException(key);

            if (!Uri.IsWellFormedUriString(serviceDirectoryApiBaseAddress, UriKind.Absolute))
                throw new ArgumentException(key);

            _logger.LogDebug("Postcode.IO base address {serviceDirectoryApi:baseAddress}", serviceDirectoryApiBaseAddress);

            _client.BaseAddress = new Uri(serviceDirectoryApiBaseAddress);
            _client.Timeout = new TimeSpan(0, 0, 15);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<PostcodeIOResponse> GetPostcodeAsync(string postcode)
        {
            using (var queryResponse = await _client.GetAsync($"postcode/{Uri.EscapeDataString(postcode)}"))
            {
                if (queryResponse.StatusCode != System.Net.HttpStatusCode.OK && queryResponse.StatusCode != System.Net.HttpStatusCode.NotFound)
                    throw new Exception($"Failed to query API for postcode {postcode}. HTTP Staus Code = {queryResponse.StatusCode}");

                string content = await queryResponse.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

                var result = JsonConvert.DeserializeObject<PostcodeIOResponse>(content);

                return result!;
            }
        }
    }
}
