namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Data;
using fh_family_experience_web.Data.Entities;
using fh_family_experience_web.Filters;
using fh_family_experience_web.Models;
using fh_family_experience_web.Services;
using fh_family_experience_web.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

[PageHistory]
public class FamilyHubResultsModel : PageModel
{
    private readonly IReadRepository _repository;
    private readonly ILocalAuthorityLookupService _localAuthorityLookupService;
    private readonly IServiceDirectoryApiClient _serviceDirectoryApi;

    public FamilyHubResultsModel(IReadRepository repository, ILocalAuthorityLookupService localAuthorityLookupService, 
        IServiceDirectoryApiClient serviceDirectoryApiClient)
    {
        _repository = repository;
        _localAuthorityLookupService = localAuthorityLookupService;
        _serviceDirectoryApi = serviceDirectoryApiClient;

        FamilyHubs = new List<Service>();
    }

    [TempData]
    public string LocalAuthority { get; set; } = "";

    [TempData]
    public string PostCode { get; set; } = "";

    public IList<Service> FamilyHubs { get; set; }

    public async Task OnGet()
    {
        var postcodeIoResponse = JsonSerializer.Deserialize<PostcodeIOResponse>(TempData["postcodeIoResponse"] as string);

        var laCode = TempData["LocalAuthorityCode"] as string;
        double longitude = 0.0;
        double latitude = 0.0;
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
