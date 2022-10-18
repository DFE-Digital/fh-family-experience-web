namespace fh_family_experience_web.Data.Entities;

using fh_family_experience_web.Data.Enums;

public class RegularSchedule : EntityBase
{
    public int? WeekDay { get; set; } = null;
    public DateTime? OpensAt { get; set; } = null!;
    public DateTime? ClosesAt { get; set; } = null!;
    public DateTime? ValidFrom { get; set; } = null!;
    public DateTime? ValidTo { get; set; } = null!;
    public DateTime? DtStart { get; set; } = null!;
    public FrequencyTypes? Frequency { get; set; } = null!;
    public int? Interval { get; set; } = null!;
    public string? ByDay { get; set; } = null!;
    public int? ByMonthDay { get; set; } = null!;
    public string? Description { get; set; } = null!;
}
