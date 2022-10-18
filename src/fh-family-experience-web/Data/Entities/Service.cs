namespace fh_family_experience_web.Data.Entities;

using fh_family_experience_web.Data.Enums;
using System.Collections.ObjectModel;

public class Service : EntityBase
{
    public virtual Organisation? Organisation { get; set; } = null!;

    public Guid OrganisationId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Accreditations { get; set; } = null!;
    public DateTime? AssuredDate { get; set; } = null!;
    public AttendingAccess? AttendingAccess { get; set; } = null!;
    public AttendingTypes? AttendingType { get; set; } = null!;
    public DeliverableTypes? DeliverableType { get; set; } = null!;
    public ServiceStatus? Status { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Fees { get; set; } = null!;
    public virtual ICollection<Eligibility> Eligibilities { get; set; } = new Collection<Eligibility>();
    public virtual ICollection<Funding> Fundings { get; set; } = new Collection<Funding>();
    public virtual ICollection<HolidaySchedule> HolidaySchedules { get; set; } = new Collection<HolidaySchedule>();
    public virtual ICollection<Language> Languages { get; set; } = new Collection<Language>();
    public virtual ICollection<RegularSchedule> RegularSchedules { get; set; } = new Collection<RegularSchedule>();
    public virtual ICollection<Review> Reviews { get; set; } = new Collection<Review>();
    public virtual ICollection<Contact> Contacts { get; set; } = new Collection<Contact>();
    public virtual ICollection<CostOption> CostOptions { get; set; } = new Collection<CostOption>();
    public virtual ICollection<ServiceArea> ServiceAreas { get; set; } = new Collection<ServiceArea>();
    public virtual ICollection<ServiceAtLocation> ServiceAtLocations { get; set; } = new Collection<ServiceAtLocation>();
    public virtual ICollection<ServiceTaxonomy> ServiceTaxonomies { get; set; } = new Collection<ServiceTaxonomy>();
}
