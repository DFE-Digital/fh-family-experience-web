namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class Taxononmy : EntityBase
{
    public Guid? ParentId { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public string? Vocabulary { get; set; } = null!;
}
