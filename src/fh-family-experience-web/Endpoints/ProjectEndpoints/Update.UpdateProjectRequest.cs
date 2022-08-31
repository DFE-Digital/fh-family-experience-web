namespace fh_family_experience_web.Endpoints.ProjectEndpoints;
using System.ComponentModel.DataAnnotations;

public class UpdateProjectRequest
{
    public const string Route = "/Projects";
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}
