namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public  class Phone : EntityBase
{
    public string? Number { get; set; } = null!;
    public string? Language { get; set; } = null!;
}
