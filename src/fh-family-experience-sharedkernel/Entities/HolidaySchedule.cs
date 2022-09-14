namespace fh_family_experience_sharedkernel.Entities;

public class HolidaySchedule : EntityBase
{
    public List<Service>? ServiceId { get; set; } = null!;
    public List<ServiceAtLocation>? ServiceAtLocationId { get; set; } = null!;
    public Boolean? Closed { get; set; } = null!;
    public DateTime? OpensAt { get; set; } = null!;
    public DateTime? ClosesAt { get; set; } = null!;
    public DateTime? SatrtDate { get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
}
