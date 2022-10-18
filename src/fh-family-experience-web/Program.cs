using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using fh_family_experience_web.Infrastructure.IoC;
using fh_family_experience_web.Services;
using fh_family_experience_web.Data;
using fh_family_experience_web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext(connectionString);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRazorPages().AddRazorPagesOptions(
  options =>
  {
      options.Conventions.AddPageRoute("/Index", "home");
      options.Conventions.AddPageRoute("/FamilyHub", "family-hub");
      options.Conventions.AddPageRoute("/FamilyHubResults", "find-hub-results");
      options.Conventions.AddPageRoute("/FindServicesOverview", "find-services-overview");
      options.Conventions.AddPageRoute("/FindServicesGroupOrActivity", "find-services-group-or-activity");
      options.Conventions.AddPageRoute("/FamilyHRBadJourney", "family-hr-bad-journey");
  }).AddSessionStateTempDataProvider();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FX API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddHttpClient();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    //containerBuilder.RegisterModule(new DefaultCoreModule());
    //containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.IsDevelopment()));
    containerBuilder.RegisterType<PostcodeLookupService>().As<IPostcodeLookupService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<LocalAuthorityLookupService>().As<ILocalAuthorityLookupService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<LocalAuthorityCache>().As<ILocalAuthorityCache>().SingleInstance();
    containerBuilder.RegisterType<EfRepository>().As<IReadRepository>().InstancePerLifetimeScope();
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
app.UseCookiePolicy();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FX API"));

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
