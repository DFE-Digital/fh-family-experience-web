namespace fh_family_experience_web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ProjectListResponse>
{
    public List() { }

    [HttpGet("/Projects")]
    [SwaggerOperation(
        Summary = "",
        Description = "",
        OperationId = "",
        Tags = new[] { "ProjectEndpoints" })
    ]
    public override async Task<ActionResult<ProjectListResponse>> HandleAsync(
      CancellationToken cancellationToken = new())
    {
        var response = new ProjectListResponse();

        return Ok(response);
    }
}
