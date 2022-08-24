using fh_family_experience_web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRazorPages().AddRazorPagesOptions(
  options =>
  {
      options.Conventions.AddPageRoute("/Index", "home");
      options.Conventions.AddPageRoute("/FamilyHub", "family-hub");
      options.Conventions.AddPageRoute("/FindServicesOverview", "find-services-overview");
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/500");
    app.UseHsts();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Shared/Errors?errorNum={0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapRazorPages();

app.Run();
