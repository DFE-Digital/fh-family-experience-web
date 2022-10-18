using fh_family_experience_web.Filters;
using fh_family_experience_web.Helpers;
using fh_family_experience_web.Models;
using fh_family_experience_web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace fh_family_experience_web.Pages;

[PageHistory]
public class FamilyHubModel : PageModel
{
    private readonly IPostcodeLookupService _postcodeLookupService;

    public FamilyHubModel(IPostcodeLookupService postcodeLookupService)
    {
        _postcodeLookupService = postcodeLookupService;
    }

    [BindProperty]
    [MinLength(3)]
    [Required]
    public string? Postcode { get; set; } = null!;

    public PostcodeIOResponse? PostcodeIOResponse { get; set; } = null!;

    [TempData]
    public string LocalAuthorityCode { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.Clear();
            ModelState.AddModelError(nameof(Postcode), "You need to enter a postcode, like AA1 1AA.");
            return Page();
        }

        if (!PostcodeValidation.IsPostCode(Postcode ?? string.Empty))
        {
            ModelState.AddModelError(nameof(Postcode), "You need to enter a valid postcode, like AA1 1AA.");
            return Page();
        }

        ModelState.Clear();

        TempData["PostCode"] = Postcode;
        PostcodeIOResponse = await _postcodeLookupService.GetPostcodeAsync(Postcode);

        if (PostcodeIOResponse!.Status == "200")
        {
            LocalAuthorityCode = PostcodeIOResponse.GetLocalAuthorityCode();
            return new RedirectResult("familyhubresults");
        }

        ModelState.AddModelError(nameof(Postcode), "Your postcode is not recognised - try another one.");
        return Page();
    }
}
