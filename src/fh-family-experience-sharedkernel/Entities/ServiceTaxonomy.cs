namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class ServiceTaxonomy : EntityBase
{
    public virtual ICollection<Service>? ServiceId { get; set; } = null!;
    public virtual ICollection<Taxononmy>? TaxononmyId { get; set; } = null!;
}
