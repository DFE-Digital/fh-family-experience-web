namespace fh_family_experience_sharedkernel.Entities;

public class HolidaySchedule :EntityBase
{
    public ServiceItem? ServiceItemId { get; set; } = null!;
    public ServiceAtLocation? ServiceAtLocationId { get; set; } = null!;
    public Boolean? Closed { get; set; } = null!;
    public DateTime? OpensAt { get; set; } = null!;
    public DateTime? ClosesAt { get; set; } = null!;
    public DateTime? SatrtDate{ get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
}
