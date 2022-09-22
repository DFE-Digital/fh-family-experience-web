namespace fh_family_experience_api.DataContext;

using fh_family_experience_infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ApiContext : AppDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "fx-family-experience");
    }
}
