namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class ServiceTaxonomy : EntityBase
{
    public string? LinkId { get; set; } = null!;
    public Taxonomy? Taxonomy { get; set; } = null!;
}
