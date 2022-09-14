namespace fh_family_experience_sharedkernel.Entities;
public class ServiceAtLocation : EntityBase
{
    public virtual ICollection<Service>? ServiceId { get; set; } = null!;
    public virtual ICollection<Location>? LocationId { get; set; } = null!;
}
