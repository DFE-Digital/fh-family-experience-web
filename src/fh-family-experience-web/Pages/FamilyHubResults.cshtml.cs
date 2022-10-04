namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Filters;
using fh_family_experience_web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[PageHistory]
public class FamilyHubResultsModel : PageModel
{
    [TempData]
    public string LocalAuthority { get; set; } = "";

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
