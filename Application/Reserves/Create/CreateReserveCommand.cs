using Application.Reserves.Common;
using ErrorOr;
using MediatR;
namespace Application.Reserves.Create;

public record CreateReserveCommand(Guid CustomerId, List<CreateLineDestineCommand> Packages) : IRequest<ErrorOr<ReserveResponse>>;

public record CreateLineDestineCommand(
    Guid PackageId, 
    decimal Price);
