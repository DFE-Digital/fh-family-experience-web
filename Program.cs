using fh_family_experience_web.Services;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRazorPages().AddRazorPagesOptions(
  options =>
  {
      options.Conventions.AddPageRoute("/Index", "home");
      options.Conventions.AddPageRoute("/FamilyHub", "family-hub");
      options.Conventions.AddPageRoute("/FamilyHubResults", "find-hub-results");
      options.Conventions.AddPageRoute("/FindServicesOverview", "find-services-overview");

      options.Conventions.AddPageRoute("/FindServicesGroupOrActivity", "find-services-group-or-activity");

      /* Page pending development */
      options.Conventions.AddPageRoute("/Errors", "family-hub-results-bad-journey");
  });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/500");
    app.UseStatusCodePagesWithRedirects("/Shared/Errors?errorNum={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapRazorPages();

app.Run();
