namespace fh_family_experience_sharedkernel.Entities;
public class ServiceCatagory : EntityBase
{
    public string? Name { get; private set; } = null!;

    private List<Service> _items = new();
    public IEnumerable<Service> Items => _items.AsReadOnly();

}
