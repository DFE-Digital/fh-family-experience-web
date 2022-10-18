namespace fh_family_experience_web.Data.Entities;
public class PhysicalAddress : EntityBase
{
    public string? Address1 { get; set; } = null!;
    public string? City { get; set; } = null!;
    public string? StateProvince { get; set; } = null!;
    public string? Postcode { get; set; } = null!;
    public string? Country { get; set; } = null!;
    public Guid LocationId { get; set; }
}
