using Application.Packages.Common;
using Domain.Packages;
using ErrorOr;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packages.GetById
{
    internal sealed class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, ErrorOr<PackageResponse>>
    {
        private readonly IPackageRepository _packageRepository;

        public GetPackageByIdQueryHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
        }

        public async Task<ErrorOr<PackageResponse>> Handle(GetPackageByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _packageRepository.GetByIdAsync(new PackageId(query.Id)) is not Package package)
            {
                return Error.NotFound("Package.NotFound", "The package with the provided Id was not found.");
            }

            var packageResponse = new PackageResponse(
                package.Id.Value,
                package.Name,
                package.Sku.Value,
                package.Description,
                package.TravelDate.ToString(), // Convertir a string según el formato deseado
                new MoneyResponse(package.Price.Currency, package.Price.Amount)
            );

            return packageResponse;
        }
    }
}
