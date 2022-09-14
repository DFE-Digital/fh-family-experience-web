namespace fh_family_experience_api.Controllers;

using fh_family_experience_api.Interfaces;
using fh_family_experience_sharedkernel.Entities;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<Organisation> GetOrganisations()
    {
        List<Organisation>? listOfOrgs = _irepository?.GetOrganisations() ?? new();
        return listOfOrgs.AsEnumerable();
    }
}
