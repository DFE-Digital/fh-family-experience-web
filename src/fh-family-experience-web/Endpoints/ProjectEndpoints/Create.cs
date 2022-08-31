namespace fh_family_experience_web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateProjectRequest>
  .WithActionResult<CreateProjectResponse>
{

    public Create() { }

    [HttpPost("/Projects")]
    [SwaggerOperation(
      Summary = "Creates a new Project",
      Description = "Creates a new Project",
      OperationId = "Project.Create",
      Tags = new[] { "ProjectEndpoints" })
    ]
    public override async Task<ActionResult<CreateProjectResponse>> HandleAsync(
      CreateProjectRequest request,
      CancellationToken cancellationToken = new())
    {
        if (request.Name == null)
        {
            return BadRequest();
        }

        var response = new CreateProjectResponse();

        return Ok(response);
    }
}
