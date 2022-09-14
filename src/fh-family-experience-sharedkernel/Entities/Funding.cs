namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class Funding : EntityBase
{
    public virtual ICollection<Service>? ServiceId { get; set; } = null!;
    public string? Source { get; set; } = null!;
}
