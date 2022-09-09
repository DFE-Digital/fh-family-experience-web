namespace fh_family_experience_web.Endpoints.ProjectEndpoints;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateProjectRequest>
    .WithActionResult<UpdateProjectResponse>
{
    public Update() {    }

    [HttpPut(UpdateProjectRequest.Route)]
    [SwaggerOperation(
        Summary = "Updates a Project",
        Description = "Updates a Project with a longer description",
        OperationId = "Projects.Update",
        Tags = new[] { "ProjectEndpoints" })
    ]
    public override async Task<ActionResult<UpdateProjectResponse>> HandleAsync(
      UpdateProjectRequest request,
        CancellationToken cancellationToken = new())
    {
        if (request.Name == null)
        {
            return BadRequest();
        }

        var response = new UpdateProjectResponse();

        return Ok(response);
    }
}
