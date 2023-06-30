using Domain.Packages;
using Domain.ValueObjects;


namespace Domain.Reservation;

public sealed class LineDestination
{
    public LineDestination(LineDestinationId Id, PackageId packageId, Money price)
    {
        this.Id = Id;
        PackageId = packageId;
        Price = price;
    }

    public LineDestination() 
    {
        
    }
    public LineDestinationId Id { get; set; }
    public PackageId PackageId { get; private set; }  
    public Money Price { get; private set; }
    public ReserveId ReserveId { get; private set; }
}
