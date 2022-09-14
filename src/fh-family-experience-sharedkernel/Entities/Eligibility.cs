namespace fh_family_experience_sharedkernel.Entities;

using fh_family_experience_sharedkernel.Enums;
using System.Collections.Generic;

public class Eligibility : EntityBase
{
    public virtual List<Service>? ServiceId { get; set; } = null!;
    public EligibilityTypes? EligibilityType { get; set; } = null!;
    public int? MinimumAge { get; set; } = null!;
    public int? MaximumjAge { get; set; } = null!;
}
