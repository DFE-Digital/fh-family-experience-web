namespace fh_family_experience_web.Data.Entities;
using System.Collections.ObjectModel;

public class Organisation : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public string? Logo { get; set; } = null!;
    public string? LogoUrl { get; set; } = null!;
    public virtual ICollection<Review>? Reviews { get; set; } = new Collection<Review>();
    public virtual ICollection<Service>? Services { get; set; } = new Collection<Service>();
}