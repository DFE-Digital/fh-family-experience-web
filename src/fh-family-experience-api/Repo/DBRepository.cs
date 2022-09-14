namespace fh_family_experience_api.Repo;

using fh_family_experience_api.DataContext;
using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class DBRepository : IRepository
{
    public DBRepository()
    {
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
                    Url="www.google.com"
                },
                new Organisation
                {
                    Description="Organisation 2",
                    Email="org2@org.com",
                    Name="Name 2",
                    LogoUrl="www.google.com",
                    Logo="image2",
                    Url="www.google.com"
                }
                };

        context.Organisations.AddRange(organisations);
        context.SaveChanges();

        List<Service> services = new()
        {
            new Service
            {
                  Fees = "£50.00",
                  Name = "Name Of Service",
                  

            }
        };

    }

    public List<Organisation> GetOrganisations()
    {
        using var context = new ApiContext();
        List<Organisation> list = context.Organisations.ToList();
        return list;
    }
}
