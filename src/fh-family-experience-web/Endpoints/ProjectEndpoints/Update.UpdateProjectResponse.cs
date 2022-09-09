namespace fh_family_experience_web.Endpoints.ProjectEndpoints;

using fh_family_experience_web.Endpoints.Records;

public class UpdateProjectResponse
{
    public UpdateProjectResponse()
    {
    }

    public UpdateProjectResponse(ProjectRecord project)
    {
        Project = project;
    }
    public ProjectRecord Project { get; set; }
}
