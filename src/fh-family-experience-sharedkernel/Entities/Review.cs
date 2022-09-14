namespace fh_family_experience_sharedkernel.Entities;
using System;
using System.Collections.Generic;

public class Review : EntityBase
{
    public ICollection<Service>? ServiceId { get; set; } = null!;
    public ICollection<Organisation>? ReviewerOrganisationId { get; set; } = null!;
    public string? Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public DateTime? Date { get; set; } = null!;
    public string? Score { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public string? Widget { get; set; } = null!;
}
