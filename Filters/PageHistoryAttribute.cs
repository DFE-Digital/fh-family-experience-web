namespace fh_family_experience_web.Filters;

using fh_family_experience_web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class)]
public class PageHistoryAttribute : ResultFilterAttribute
{
    public const string PageHistorySessionKey = "PageHistory";

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        if (context?.HttpContext?.Request?.Method is not null
            && context.HttpContext.Request.Method.ToUpper() == "POST"
            && context.Result is RedirectToPageResult or RedirectResult)
        {
            List<string> pageHistory = context.HttpContext.Session.GetOrDefault<List<string>>(PageHistorySessionKey) ?? new();
            pageHistory.Add(context.HttpContext.Request.Path);
            context.HttpContext.Session.Put(PageHistorySessionKey, pageHistory);
        }
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context?.HttpContext?.Request?.Method is not null && context.HttpContext.Request.Method.ToUpper() == "GET")
        {
            List<string> pageHistory = context.HttpContext.Session.GetOrDefault<List<string>>(PageHistorySessionKey) ?? new();

            if (pageHistory.Any())
            {
                string currentPagePath = context.HttpContext.Request.Path.ToString();
                if (pageHistory.Last() == currentPagePath)
                {
                    pageHistory.Remove(currentPagePath);
                    context.HttpContext.Session.Put(PageHistorySessionKey, pageHistory);
                }
            }
        }
    }
}
