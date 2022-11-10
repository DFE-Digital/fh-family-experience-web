using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralLocations;
using FamilyHubs.ServiceDirectory.Shared.Models;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.Postcodes;
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

        public async Task<PostcodeIOResponseDto> GetPostcodeAsync(string postcode)
        {
            using (var queryResponse = await _client.GetAsync($"postcode/{Uri.EscapeDataString(postcode)}"))
            {
                if (queryResponse.StatusCode != System.Net.HttpStatusCode.OK && queryResponse.StatusCode != System.Net.HttpStatusCode.NotFound)
                    throw new Exception($"Failed to query API for postcode {postcode}. HTTP Staus Code = {queryResponse.StatusCode}");

                string content = await queryResponse.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

                var result = JsonConvert.DeserializeObject<PostcodeIOResponseDto>(content);

                return result!;
            }
        }

        public async Task<List<Either<OpenReferralServiceDto, OpenReferralLocationDto, double>>> GetFamilyHubsForLocalAuthorityAsync(string postcode, string localAuthorityCode, double longtitude, double latitude)
        {
            var uriSuffix = $"search?postcode={Uri.EscapeDataString(postcode)}&districtCode={Uri.EscapeDataString(localAuthorityCode)}&longitude={longtitude}&latitude={latitude}";
            using (var queryResponse = await _client.GetAsync(uriSuffix))
            {
                if (!queryResponse.IsSuccessStatusCode)
                    throw new Exception($"Failed to query Service Directory API for Family Hubs for postcode {postcode}, laCode {localAuthorityCode}, longtitude {longtitude}, latitude {latitude}. HTTP Staus Code = {queryResponse.StatusCode}");

                string content = await queryResponse.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

                var result = JsonConvert.DeserializeObject<List<Either<OpenReferralServiceDto, OpenReferralLocationDto, double>>>(content);

                return result!;
            }
        }
    }
}
