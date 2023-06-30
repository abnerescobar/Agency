using Application.Packages.Common;
using ErrorOr;
using MediatR;
using System.Collections.Generic;

namespace Application.Packages.GetAll
{
    public record GetAllPackagesQuery : IRequest<ErrorOr<IReadOnlyList<PackageResponse>>>;
}
