namespace fh_family_experience_sharedkernel.Entities;
public class Organisation : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public string? Logo { get; set; } = null!;
    public string? LogoUrl { get; set; } = null!;
}
