namespace fh_family_experience_sharedkernel.Entities;
public class ServiceCatagory : EntityBase
{
    public string? Name { get; private set; } = null!;

    private List<ServiceItem> _items = new();
    public IEnumerable<ServiceItem> Items => _items.AsReadOnly();

}
