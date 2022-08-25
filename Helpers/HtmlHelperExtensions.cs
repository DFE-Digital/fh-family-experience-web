namespace fh_family_experience_web.Helpers;

using fh_family_experience_web.ViewModels;
using fh_family_experience_web.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

public static class HtmlHelperExtensions
{
    public static ICookieViewModel GetCookieViewModel(this IHtmlHelper html)
    {
        /* Hard code for now */
        return new CookieViewModel()
        {
            Accepted = false,
            Rejected = false,
            Hide = false,
            ViewCookiesUrl = "https://www.google.com",
            CookieName = "bus.ext.sess",
            DisplayServiceName = "Family Experience",
            CurrentRoute = null
        };
    }
}
