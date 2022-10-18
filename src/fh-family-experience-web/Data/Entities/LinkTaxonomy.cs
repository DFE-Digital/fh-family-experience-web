namespace fh_family_experience_web.Data.Entities;

using fh_family_experience_web.Data.Enums;

public class LinkTaxonomy : EntityBase
{
    public LinkTypes? LinkType { get; set; } = null!;
    public string? LinkId { get; set; } = null!;
}
