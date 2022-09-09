namespace fh_family_experience_web.ViewModels;

using fh_family_experience_web.ViewModels.Interfaces;

public class CookieViewModel : ICookieViewModel
{
    public bool? Accepted { get; set; } = null!;
    public bool? Rejected { get; set; } = null!;
    public bool? Hide { get; set; } = null!;
    public string? ViewCookiesUrl { get; set; } = null!;
    public string? CookieName { get; set; } = null!;
    public string? DisplayServiceName { get; set; } = null!;
    public string? CurrentRoute { get; set; } = null!;
}
