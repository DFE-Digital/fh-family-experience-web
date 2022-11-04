namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Filters;
using fh_family_experience_web.Services;
using fh_family_experience_web.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.Postcodes;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;

[PageHistory]
public class FamilyHubResultsModel : PageModel
{
    private readonly ILocalAuthorityLookupService _localAuthorityLookupService;
    private readonly IServiceDirectoryApiClient _serviceDirectoryApi;

    public FamilyHubResultsModel(ILocalAuthorityLookupService localAuthorityLookupService, 
        IServiceDirectoryApiClient serviceDirectoryApiClient)
    {
        _localAuthorityLookupService = localAuthorityLookupService;
        _serviceDirectoryApi = serviceDirectoryApiClient;

        FamilyHubs = new List<OpenReferralServiceDto>();
    }

    [TempData]
    public string LocalAuthority { get; set; } = "";

    [TempData]
    public string PostCode { get; set; } = "";

    public IList<OpenReferralServiceDto> FamilyHubs { get; set; }

    public async Task OnGet()
    {
        var postcodeIoResponse = JsonSerializer.Deserialize<PostcodeIOResponseDto>(TempData["postcodeIoResponse"] as string);

        var laCode = TempData["LocalAuthorityCode"] as string;
        double longitude = postcodeIoResponse?.Result?.Longitude ?? 0.0;
        double latitude = postcodeIoResponse?.Result?.Latitude ?? 0.0;
        var postcode = TempData["Postcode"];

        var localAuthority = _localAuthorityLookupService.GetLocalAuthorityFromCode((string)laCode);

        if (localAuthority != null)
        {
            LocalAuthority = localAuthority.AuthorityName;
        } else
        {
            LocalAuthority = "Unknown";
        }

        FamilyHubs = await _serviceDirectoryApi.GetFamilyHubsForLocalAuthorityAsync(PostCode, laCode, longitude, latitude);
    }

    public IActionResult OnPost()
    {
        return new RedirectResult("FindServicesOverview");
    }

    public IActionResult OnPostBadJourney()
    {
        return new RedirectResult("FamilyHRBadJourney");
    }
    
}
