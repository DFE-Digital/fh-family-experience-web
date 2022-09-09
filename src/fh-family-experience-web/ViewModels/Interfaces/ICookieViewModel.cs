namespace fh_family_experience_web.ViewModels.Interfaces;

public interface ICookieViewModel
{
    public bool? Accepted { get; set; }
    public bool? Rejected { get; set; }
    public bool? Hide{ get; set; }
    public string? ViewCookiesUrl { get; set; }
    public string? CookieName { get; set; }
    public string? DisplayServiceName { get; set; }
    public string? CurrentRoute { get; set; }
}
