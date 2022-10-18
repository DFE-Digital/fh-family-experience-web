namespace fh_family_experience_web.Data.Entities;

using fh_family_experience_web.Data.Enums;
using System.Collections.Generic;

public class Eligibility : EntityBase
{
    public EligibilityTypes? EligibilityTypes { get; set; } = null!;
    public string? LinkId { get; set; } = null!;
    public int? MaximumAge { get; set; } = null!;
    public int? MinimumAge { get; set; } = null!;
    public ICollection<Taxonomy>? Taxonomies { get; set; } = null!;
}
