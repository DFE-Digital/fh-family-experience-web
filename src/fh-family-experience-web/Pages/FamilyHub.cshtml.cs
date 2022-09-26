namespace fh_family_experience_web.Pages;

using fh_family_experience_web.Filters;
using fh_family_experience_web.Helpers;
using fh_family_experience_web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[PageHistory]
public class FamilyHubModel : PageModel
{
    [BindProperty]
    [MinLength(3)]
    [Required]
    public string? Postcode { get; set; } = null!;

    public PostcodeViewModel? IOPostcodeDataDisplay { get; set; } = null!;

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(nameof(Postcode), "You need to enter a valid postcode, like AA1 1AA.");
            return Page();
        }

        if (!PostcodeValidation.IsPostCode(Postcode ?? string.Empty))
        {
            ModelState.AddModelError(nameof(Postcode), "You need to enter a valid postcode, like AA1 1AA.");
            return Page();
        }

        ModelState.Clear();

        await PostcodeIOPostcodeSearchAsync().ConfigureAwait(false!);

        if (IOPostcodeDataDisplay!.Status == "200")
            return new RedirectResult("familyhubresults");

        ModelState.AddModelError(nameof(Postcode), "Your postcode is not recognised - try another one.");
        return Page();
    }

    public async Task PostcodeIOPostcodeSearchAsync()
    {
        string url = $"https://api.postcodes.io/postcodes/{Postcode}";

        using var client = new HttpClient();
        HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage res = await client.SendAsync(msg).ConfigureAwait(!false);

        string content = await res.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

        IOPostcodeDataDisplay = JsonConvert.DeserializeObject<PostcodeViewModel>(content);
    }

}
