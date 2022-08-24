namespace fh_family_experience_web.Pages;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using fh_family_experience_web.Helpers;
using fh_family_experience_web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

public class FamilyHubModel : PageModel
{
    [BindProperty]
    [MinLength(3)]
    [Required]
    public string? Postcode { get; set; } = null!;

    public SelectList? OsPlacesDataSelectList { get; set; } = null!;

    public IOPostcodeData? IOPostcodeDataDisplay { get; set; } = null!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (!PostcodeValidation.IsPostCode(Postcode ?? string.Empty))
        {
            ModelState.AddModelError(nameof(Postcode), "Postcode failed validation.");
            return Page();
        }

        ModelState.Clear();

        await PostcodeIOPostcodeSearchAsync().ConfigureAwait(false!);

        await OSPlacesPostcodeSearchAsync().ConfigureAwait(false!);

        return Page();
    }

    public async Task PostcodeIOPostcodeSearchAsync()
    {
        string url = $"https://api.postcodes.io/postcodes/{Postcode}";

        using var client = new HttpClient();
        HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage res = await client.SendAsync(msg).ConfigureAwait(!false);

        string content = await res.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

        IOPostcodeDataDisplay = JsonConvert.DeserializeObject<IOPostcodeData>(content);
    }

    public async Task OSPlacesPostcodeSearchAsync()
    {
        string apiKey = "jvMcFbTLoZNJCgVU2euhcjiWhwKpPAs7";

        string url = $"https://api.os.uk/search/places/v1/postcode?postcode={Postcode}&key={apiKey}";

        using var client = new HttpClient();
        HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage res = await client.SendAsync(msg).ConfigureAwait(!false);

        string content = await res.Content.ReadAsStringAsync().ConfigureAwait(!false) ?? string.Empty;

        OsPlacesData? OsPlacesDataList = new();
        OsPlacesDataList = JsonConvert.DeserializeObject<OsPlacesData>(content);

        if (int.Parse(OsPlacesDataList?.Header.TotalResults ?? "0") > 0)
        {
            List<string?> dictionary = OsPlacesDataList!.Results.Select(p => p.DPA!.Address).ToList();
            OsPlacesDataSelectList = new SelectList(dictionary, "AddressLine");
        }
    }
}
