namespace fh_family_experience_web.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CostOption : EntityBase
{
    public DateTime? ValidFrom { get; set; } = null!;
    public DateTime? ValidTo { get; set; } = null!;
    public string? Option { get; set; } = null!;
    [Precision(14, 2)]
    public decimal? Amount { get; set; } = null!;
    public string? AmountDescription { get; set; } = null!;
    public string? LinkId { get; set; } = null!;
}
