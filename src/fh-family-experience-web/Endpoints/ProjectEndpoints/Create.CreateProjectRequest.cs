namespace fh_family_experience_web.Endpoints.ProjectEndpoints;
using System.ComponentModel.DataAnnotations;

public class CreateProjectRequest
{
    public const string Route = "/Projects";

    [Required]
    public string? Name { get; set; }
}
