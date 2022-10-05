namespace fh_family_experience_infrastructure;

using fh_family_experience_infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "fx-family-experience"));
}
