using MediatR;
using ErrorOr;
using Application.Packages.Common;

namespace Application.Packages.Create;

public record CreatePackageCommand(
    string Name,
    string Description,
    string Sku,
    DateTime TravelDate,
    string Currency, 
    decimal Amount) : IRequest<ErrorOr<PackageResponse>>;
