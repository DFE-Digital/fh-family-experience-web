using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralLocations;
using FamilyHubs.ServiceDirectory.Shared.Models.Api.OpenReferralServices;
using FamilyHubs.ServiceDirectory.Shared.Models;
using System.Linq;

namespace fh_family_experience_web.ViewModels.Extensions
{
    public static class FamilyHubViewModelExtensions
    {
        public static IList<FamilyHubViewModel> ToFamilyHubViewModels(this IList<Either<OpenReferralServiceDto, OpenReferralLocationDto, double>> hubsAndServices)
        {
            var results = new List<FamilyHubViewModel>();

            if(hubsAndServices != null)
            {
                foreach(var location in hubsAndServices.Where(h => h.Second != null).OrderBy(l => l.Third))
                {
                    var hub = new FamilyHubViewModel { Name = location.Second.Name };

                    if(location.Second.Physical_addresses != null && location.Second.Physical_addresses.FirstOrDefault() != null)
                    {
                        var addr = location.Second.Physical_addresses.First();

                        hub.Address1 = addr.Address_1 ?? "";
                        hub.City = addr.City ?? "";
                        hub.StateProvince = addr.State_province ?? "";
                        hub.Postcode = addr.Postal_code ?? "";
                        hub.Email = "";  // TODO: SR - Determine where Email needs to come from. Currently not supported in the model.
                        hub.Telephone = ""; // TODO: SR - Determine where Tel needs to come from. Currently not supported in the model.
                    }

                    const double metersPerMile = 1609.34;
                    hub.Distance = location.Third / metersPerMile;

                    results.Add(hub);
                }
            }

            return results;
        }
    }
}
