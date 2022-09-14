namespace fh_family_experience_sharedkernel.Entities;

using fh_family_experience_sharedkernel.Enums;

public class LinkTaxonomy : EntityBase
{
    public LinkTypes? LinkType { get; set; } = null!;
    public string? LinkId { get; set; } = null!;
    public Guid? TaxononmyId { get; set; } = null!;
}
