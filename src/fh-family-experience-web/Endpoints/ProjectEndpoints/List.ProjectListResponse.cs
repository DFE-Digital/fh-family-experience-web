namespace fh_family_experience_web.Endpoints.ProjectEndpoints;

using fh_family_experience_web.Endpoints.Records;

public class ProjectListResponse
{
    public List<ProjectRecord> Projects { get; set; } = new();
}
