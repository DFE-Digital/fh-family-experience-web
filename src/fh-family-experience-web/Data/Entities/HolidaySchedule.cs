namespace fh_family_experience_web.Data.Entities;

public class HolidaySchedule : EntityBase
{
    public Boolean? Closed { get; set; } = null!;
    public DateTime? OpensAt { get; set; } = null!;
    public DateTime? ClosesAt { get; set; } = null!;
    public DateTime? SatrtDate { get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
}
