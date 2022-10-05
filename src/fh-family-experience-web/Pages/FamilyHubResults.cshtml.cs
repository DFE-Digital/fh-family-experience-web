namespace fh_family_experience_web.Pages;

using fh_family_experience_sharedkernel.Entities;
using fh_family_experience_sharedkernel.Interfaces;
using fh_family_experience_web.Filters;
using fh_family_experience_web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[PageHistory]
public class FamilyHubResultsModel : PageModel
{
    private readonly IReadRepository _repository;

    public FamilyHubResultsModel(IReadRepository repository)
    {
        _repository = repository;
    }

    [TempData]
    public string LocalAuthority { get; set; } = "";

    [TempData]
    public string PostCode { get; set; } = "";

    public List<Service> FamilyHubs { get; set; }

    public void OnGet()
    {
        var laCode = TempData["LocalAuthorityCode"];
        if(laCode != null && !string.IsNullOrWhiteSpace((string)laCode) && LocalAuthorityLookup.AuthorityCache.ContainsKey((string)laCode))
        {
            LocalAuthority = LocalAuthorityLookup.AuthorityCache[(string)laCode];
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
