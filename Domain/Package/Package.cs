using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Packages;

public sealed class Package : AggregateRoot
{
    public Package(PackageId id, Sku sku, string name, string description, DateTime travelDate, Money price)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Description = description;
        TravelDate = travelDate;
        Price = price;
    }

    private Package()
    {

    }
    public PackageId Id { get; private set; }
    public Sku Sku { get; private set; } 
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; }
    public DateTime TravelDate { get; private set; } 
    public Money Price { get; private set; }

    public void Update(string name, DateTime travelDate, Money price, Sku sku)
    {
        Name = name;
        TravelDate = travelDate;
        Price = price;
        Sku = sku;
    }
}
