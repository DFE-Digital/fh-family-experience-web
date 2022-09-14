namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class ServiceArea : EntityBase
{
    public virtual List<Service>? ServiceId { get; set; } = null!;
    public string? Area { get; set; } = null!;
    public string? Extent { get; set; } = null!;
    public string? Uri { get; set; } = null!;
}
