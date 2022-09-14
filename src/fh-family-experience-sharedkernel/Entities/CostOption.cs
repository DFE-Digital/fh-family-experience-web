namespace fh_family_experience_sharedkernel.Entities;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CostOption : EntityBase
{
    public virtual List<Service>? ServiceId { get; set; } = null!;
    public DateTime? ValidFrom { get; set; } = null!;
    public DateTime? ValidTo { get; set; } = null!;
    public string? Option { get; set; } = null!;
    [Precision(14, 2)]
    public decimal? Amount { get; set; } = null!;
    public string? AmountDescription { get; set; } = null!;
}
