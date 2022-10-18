namespace fh_family_experience_web.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public string? CreatedBy { get; set; } = null!;
    public DateTime? CreatedDate { get; set; } = null!;
    public string? LastUpdatedBy { get; set; } = null!;
    public DateTime? LastUpdated { get; set; } = null!;
}
