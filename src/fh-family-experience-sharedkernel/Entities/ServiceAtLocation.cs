namespace fh_family_experience_sharedkernel.Entities;
public class ServiceAtLocation : EntityBase
{
    public virtual ServiceItem? ServiceItemId { get; set; } = null!;
    public virtual Location? LocationId { get; set; } = null!;
}
