namespace NimblePros.DotNetConf.Web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using fh_family_experience_web.Endpoints.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;


using Swashbuckle.AspNetCore.Annotations;

public class GetById : EndpointBaseAsync
  .WithRequest<GetProjectByIdRequest>
  .WithActionResult<GetProjectByIdResponse>
{

    public GetById() { }

    [HttpGet(GetProjectByIdRequest.Route)]
    [SwaggerOperation(
      Summary = "",
      Description = "",
      OperationId = "",
      Tags = new[] { "ProjectEndpoints" })
    ]
    public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync(
      [FromRoute] GetProjectByIdRequest request,
      CancellationToken cancellationToken = new())
    {
        var response = new GetProjectByIdResponse();

        return Ok(response);
    }
}
