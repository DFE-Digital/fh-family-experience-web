namespace fh_family_experience_sharedkernel.Entities;

using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Eligibility : EntityBase
{
    public string OpenReferralOrganisationId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Accreditations { get; set; }
    public DateTime? Assured_date { get; set; }
    public string? Attending_access { get; set; }
    public string? Attending_type { get; set; }
    public string? Deliverable_type { get; set; }
    public string? Status { get; set; }
    public string? Url { get; set; }
    public string? Email { get; set; }
    public string? Fees { get; set; }
    public virtual ICollection<Eligibility> Eligibilities { get; set; } = new Collection<Eligibility>();
    public virtual ICollection<Funding> Fundings { get; set; } = new Collection<Funding>();
    public virtual ICollection<HolidaySchedule> HolidaySchedules { get; set; } = new Collection<HolidaySchedule>();
    public virtual ICollection<Language> Languages { get; set; } = new Collection<Language>();
    public virtual ICollection<RegularSchedule> RegularSchedules { get; set; } = new Collection<RegularSchedule>();
    public virtual ICollection<Review> Reviews { get; set; } = new Collection<Review>();
    public virtual ICollection<Contact> Contacts { get; set; } = new Collection<Contact>();
    public virtual ICollection<CostOption> Cost_options { get; set; } = new Collection<CostOption>();
    public virtual ICollection<ServiceArea> ServiceAreas { get; set; } = new Collection<ServiceArea>();
    public virtual ICollection<ServiceAtLocation> ServiceAtLocations { get; set; } = new Collection<ServiceAtLocation>();
    public virtual ICollection<ServiceTaxonomy> Taxonomies { get; set; } = new Collection<ServiceTaxonomy>();
}
