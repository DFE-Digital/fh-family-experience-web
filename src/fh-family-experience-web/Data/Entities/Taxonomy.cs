namespace fh_family_experience_web.Data.Entities;
using System.Collections.Generic;

public class Taxonomy : EntityBase
{
    public string? Name { get; set; } = null!;
    public string? Vocabulary { get; set; } = null!;
    public string? ParentId { get; set; } = null!;
    public virtual ICollection<LinkTaxonomy>? LinkTaxonomies { get; set; } = null!;
}