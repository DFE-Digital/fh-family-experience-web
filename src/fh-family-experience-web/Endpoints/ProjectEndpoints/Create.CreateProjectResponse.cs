namespace fh_family_experience_web.Endpoints.ProjectEndpoints;

public class CreateProjectResponse
{
    public CreateProjectResponse()
    {
    }

    public CreateProjectResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
}
