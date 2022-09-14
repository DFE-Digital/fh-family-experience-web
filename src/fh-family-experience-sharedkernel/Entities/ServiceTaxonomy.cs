namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class ServiceTaxonomy : EntityBase
{
    public virtual List<Service>? ServiceId { get; set; } = null!;
    public virtual List<Taxononmy>? TaxononmyId { get; set; } = null!;
}
