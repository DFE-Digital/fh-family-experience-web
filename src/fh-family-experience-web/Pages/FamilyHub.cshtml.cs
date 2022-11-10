using fh_family_experience_web.Filters;
using fh_family_experience_web.Helpers;
using fh_family_experience_web.Services;
using fh_family_experience_web.Services.Api;
using fh_family_experience_web.Services.Postcodes;
using fh_family_experience_web.Services.Postcodes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;

namespace fh_family_experience_web.Pages;

[PageHistory]
public class FamilyHubModel : PageModel
{
    private readonly IServiceDirectoryApiClient _serviceDirectoryApiClient;
    private readonly IPostcodeLookupService _postcodeLookupService;

    public FamilyHubModel(IServiceDirectoryApiClient serviceDirectoryApiClient, IPostcodeLookupService postcodeLookupService)
    {
        _serviceDirectoryApiClient = serviceDirectoryApiClient;
        _postcodeLookupService = postcodeLookupService;

        LocalAuthorityCode = String.Empty;
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
        if (!ModelState.IsValid && string.IsNullOrWhiteSpace(Postcode))
        {
            ModelState.Clear();
            ModelState.AddModelError(nameof(Postcode), "You need to enter a postcode, like AA1 1AA.");
            return Page();
        }

        ModelState.Clear();

        if (!ModelState.IsValid || !PostcodeValidation.IsPostCode(Postcode ?? string.Empty))
        {
            ModelState.AddModelError(nameof(Postcode), "You need to enter a valid postcode, like AA1 1AA.");
            return Page();
        }

        TempData["PostCode"] = Postcode;
        PostcodeIOResponse = await _postcodeLookupService.GetPostcodeAsync(Postcode!);

        if (PostcodeIOResponse is null)
            throw new Exception("Failed to get response from Service Directory API");

        TempData["postcodeIoResponse"] = JsonSerializer.Serialize(PostcodeIOResponse);

        if (PostcodeIOResponse!.Status == "200")
        {
            LocalAuthorityCode = PostcodeIOResponse.Result!.GetLocalAuthorityCode();
            return new RedirectResult("familyhubresults");
        }

        ModelState.AddModelError(nameof(Postcode), "Your postcode is not recognised - try another one.");
        return Page();
    }
}
