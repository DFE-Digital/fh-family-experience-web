namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[PageHistory]
public class FindServicesOverviewModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        return new RedirectResult("FindServicesGroupOrActivityEmpty");
    }
}
