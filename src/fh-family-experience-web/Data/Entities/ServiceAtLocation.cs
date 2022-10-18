namespace fh_family_experience_web.Data.Entities;
public class ServiceAtLocation : EntityBase
{
    public Location? Location { get; set; } = null!;
    public Guid LocationId { get; set; }
    public Guid ServiceId { get; set; }
    public virtual ICollection<HolidaySchedule>? HolidaySchedules { get; set; } = null!;
    public virtual ICollection<RegularSchedule>? RegularSchedules { get; set; } = null!;
}