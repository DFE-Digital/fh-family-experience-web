namespace fh_family_experience_sharedkernel.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdated { get; set; }
}
