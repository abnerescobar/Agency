using Customers.Common;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;

public record GetAllPackagesQuery() : IRequest<ErrorOr<IReadOnlyList<CustomerResponse>>>;