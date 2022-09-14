namespace fh_family_experience_sharedkernel.Entities;
public class ServiceAtLocation : EntityBase
{
    public Location? Location { get; set; } = null!;
    public virtual ICollection<HolidaySchedule>? HolidayScheduleCollection { get; set; } = null!;
    public virtual ICollection<RegularSchedule>? RegularSchedule { get; set; } = null!;
}