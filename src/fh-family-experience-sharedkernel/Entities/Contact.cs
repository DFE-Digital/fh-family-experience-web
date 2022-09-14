namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class Contact : EntityBase
{
    public virtual List<Service>? ServiceId { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public string? Title { get; set; } = null!;
}
