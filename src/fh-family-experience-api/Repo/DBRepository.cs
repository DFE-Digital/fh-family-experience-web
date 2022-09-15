namespace fh_family_experience_api.Repo;

using fh_family_experience_api.DataContext;
using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class DBRepository : IRepository
{
    public DBRepository()
    {
        List<Service> services = new();
        List<Review> reviews = new();

        using var context = new ApiContext();
        List<Organisation> organisations = new()
                {
                    new Organisation
                    {
                        Description="Organisation 1",
                        Email="org1@org.com",
                        Name="Name 1",
                        LogoUrl="www.google.com",
                        Logo="image1",
                        Url="www.google.com",
                        Services =  new List<Service>(),
                        Reviews = new List<Review>()
                    }
                };

        context.Organisations.AddRange(organisations);
        context.SaveChanges();

    }

    public List<Organisation> GetOrganisations()
    {
        using var context = new ApiContext();
        List<Organisation> list = context.Organisations.ToList();
        return list;
    }
}
