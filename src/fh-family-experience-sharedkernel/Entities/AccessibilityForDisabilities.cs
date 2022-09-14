namespace fh_family_experience_sharedkernel.Entities;

public class AccessibilityForDisabilities : EntityBase
{
    public virtual ICollection<Location>? LocationId { get; set; } = null!;
    public string? Accessibility { get; set; } = null!;
}
