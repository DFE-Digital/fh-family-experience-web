namespace fh_family_experience_sharedkernel.Entities;
public class Location : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
