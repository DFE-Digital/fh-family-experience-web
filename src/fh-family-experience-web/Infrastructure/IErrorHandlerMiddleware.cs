namespace fh_family_experience_web.Infrastructure;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IErrorHandlerMiddleware
{
    Task Invoke(HttpContext context);
}