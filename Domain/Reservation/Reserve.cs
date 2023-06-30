using Domain.Customers;
using Domain.Primitives;
using Domain.Packages;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reservation;
public sealed class Reserve: AggregateRoot
{
    private readonly List<LineDestination> _lineDestine = new();
    private Reserve()
    {
    }
    public ReserveId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<LineDestination> LineDestine => _lineDestine.AsReadOnly();

    public static Reserve Create(CustomerId customerId)
    {
        var reserve = new Reserve
        {
            Id = new ReserveId(Guid.NewGuid()),
            CustomerId = customerId
        };
        return reserve;
    }
    public void Add(PackageId packageId, Money price)
    {
        var lineDestine = new LineDestination(new LineDestinationId(Guid.NewGuid()), packageId, price);
        _lineDestine.Add(lineDestine);
    }
    public void RemoveLineItem(LineDestinationId lineDestinationId, IReserveRepository reserveRepository)
    {
        if (reserveRepository.HasOneLineItem(this))
        {
            return;
        }
        var lineDestine = _lineDestine.FirstOrDefault(li => li.Id == lineDestinationId);
        if (lineDestine is null) 
        {
            return;
        }
        _lineDestine.Remove(lineDestine);
    }
}
