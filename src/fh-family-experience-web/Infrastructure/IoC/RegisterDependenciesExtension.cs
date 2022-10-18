using fh_family_experience_web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace fh_family_experience_web.Infrastructure.IoC
{
    public static class RegisterDependenciesExtension
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "fx-family-experience"));
        }
    }
}
