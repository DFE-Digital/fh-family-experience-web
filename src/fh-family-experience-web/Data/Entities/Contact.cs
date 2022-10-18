namespace fh_family_experience_web.Data.Entities;
using System.Collections.Generic;

public class Contact : EntityBase
{
    public virtual ICollection<Phone>? Phones { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public string? Title { get; set; } = null!;
}
