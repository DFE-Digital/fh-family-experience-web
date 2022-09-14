namespace fh_family_experience_sharedkernel.Entities;

using fh_family_experience_sharedkernel.Enums;

public class Service : EntityBase
{
    public virtual ICollection<Organisation>? OrganisationId { get; set; } = null!;

    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public ServiceStatus? Status { get; set; } = null!;
    public string? Fees { get; set; } = null!;
    public string? Accreditations { get; set; } = null!;
    public DeliverableTypes? DeliverableType { get; set; } = null!;
    public DateTime? AssuredDate { get; set; } = null!;
    public AttendingTypes? AttendingType { get; set; } = null!;
    public AttendingAccess? AttendingAccess { get; set; } = null!;

    public override string ToString()
    {
        return $"{Id}: {Name} - {Description}";
    }
}
