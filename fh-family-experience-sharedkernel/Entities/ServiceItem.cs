namespace fh_family_experience_sharedkernel.Entities;
public class ServiceItem : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Id}: {Title} - {Description}";
    }
}
