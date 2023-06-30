using ErrorOr;
using MediatR;

namespace Application.Customers.Delete;

public record DeletePackageCommand(Guid Id) : IRequest<ErrorOr<Unit>>;