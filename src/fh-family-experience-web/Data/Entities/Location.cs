namespace fh_family_experience_web.Data.Entities;
public class Location : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public virtual ICollection<PhysicalAddress>? PhysicalAddresses { get; set; } = null!;
    public virtual ICollection<AccessibilityForDisabilities>? AccessibilityForDisabilities { get; set; } = null!;
}
