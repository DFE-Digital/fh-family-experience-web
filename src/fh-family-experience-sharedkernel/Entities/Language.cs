namespace fh_family_experience_sharedkernel.Entities;
using System.Collections.Generic;

public class Language : EntityBase
{
    public virtual ICollection<Service>? ServiceId { get; set; } = null!;
    public string? LanguagesOtherThanEnglish { get; set; } = null!;
}
