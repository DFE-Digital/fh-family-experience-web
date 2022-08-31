namespace fh_family_experience_sharedkernel.Entities;
public class ServiceAtLocation : EntityBase
{
    public virtual List<ServiceItem>? ServiceItemId { get; set; } = null!;
    public virtual List<Location>? LocationId { get; set; } = null!;
}
