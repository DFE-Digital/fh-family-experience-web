namespace fh_family_experience_web.Endpoints.ProjectEndpoints;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

public class Delete : EndpointBaseAsync
    .WithRequest<DeleteProjectRequest>
    .WithoutResult
{
    public Delete() { }

    [HttpDelete(DeleteProjectRequest.Route)]
    [SwaggerOperation(
        Summary = "Deletes a Project",
        Description = "Deletes a Project",
        OperationId = "Projects.Delete",
        Tags = new[] { "ProjectEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(
      [FromRoute] DeleteProjectRequest request,
        CancellationToken cancellationToken = new())
    {
        return NoContent();
    }
}
