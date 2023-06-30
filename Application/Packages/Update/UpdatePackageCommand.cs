using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Packages.Update;

public record UpdatePackageCommand(
    Guid Id,
    string Name,
    string Description,
    string Sku,
    string TravelDate,
    UpdateMoney Money) : IRequest<ErrorOr<Unit>>;

public record UpdateMoney(string Currency, decimal Amount);