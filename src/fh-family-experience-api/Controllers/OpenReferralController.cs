namespace fh_family_experience_api.Controllers;

using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class OpenReferralController : ControllerBase
{
    private readonly ILogger<OpenReferralController> _logger;
    private readonly IRepository? _irepository = null!;

    public OpenReferralController(ILogger<OpenReferralController> logger, IRepository irepository)
    {
        _logger = logger;
        _irepository = irepository;
    }

    [HttpGet(Name = "GetOrganisations")]
    public async Task<IEnumerable<Organisation>> GetOrganisationsAsync()
    {
        List<Organisation>? listOfOrgs = await _irepository!.GetOrganisationsAsync();
        return listOfOrgs.AsEnumerable();
    }
}
