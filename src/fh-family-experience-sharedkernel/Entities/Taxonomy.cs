namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class Taxonomy : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Vocabulary { get; set; } = null!;
    public string? ParentId { get; set; } = null!;
    public virtual ICollection<LinkTaxonomy>? LinkTaxonomyCollection { get; set; } = null!;
}