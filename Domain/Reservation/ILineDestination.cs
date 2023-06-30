using Domain.Packages;
using Domain.ValueObjects;

namespace Domain.Reservation
{
    public interface ILineDestination
    {
        LineDestinationId LineDestinationId { get; }
        ReserveId ReserveId { get; }
        Money Price { get; }
        PackageId PackageId { get; }
    }
}