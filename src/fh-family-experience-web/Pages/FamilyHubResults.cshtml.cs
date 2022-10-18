namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Data;
using fh_family_experience_web.Data.Entities;
using fh_family_experience_web.Filters;
using fh_family_experience_web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[PageHistory]
public class FamilyHubResultsModel : PageModel
{
    private readonly IReadRepository _repository;
    private readonly ILocalAuthorityLookupService _localAuthorityLookupService;

    public FamilyHubResultsModel(IReadRepository repository, ILocalAuthorityLookupService localAuthorityLookupService)
    {
        _repository = repository;
        _localAuthorityLookupService = localAuthorityLookupService;
    }

    [TempData]
    public string LocalAuthority { get; set; } = "";

    [TempData]
    public string PostCode { get; set; } = "";

    public List<Service> FamilyHubs { get; set; }

    public void OnGet()
    {
        var laCode = TempData["LocalAuthorityCode"];
        var localAuthority = _localAuthorityLookupService.GetLocalAuthorityFromCode((string)laCode);

        if (localAuthority != null)
        {
            LocalAuthority = localAuthority.AuthorityName;
        } else
        {
            LocalAuthority = "Unknown";
        }

        FamilyHubs = _repository.GetFamilyHubsForLocalAuthority(LocalAuthority).Result;
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
