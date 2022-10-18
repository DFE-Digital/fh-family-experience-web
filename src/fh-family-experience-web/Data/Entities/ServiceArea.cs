namespace fh_family_experience_web.Data.Entities;
using System.Collections.Generic;

public class ServiceArea : EntityBase
{
    public string? LinkId { get; set; } = null!;
    public string? Area { get; set; } = null!;
    public string? Extent { get; set; } = null!;
    public string? Uri { get; set; } = null!;
}

