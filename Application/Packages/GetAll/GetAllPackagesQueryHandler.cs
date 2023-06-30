using Application.Packages.Common;
using Domain.Packages;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Packages.GetAll
{
    internal sealed class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, ErrorOr<IReadOnlyList<PackageResponse>>>
    {
        private readonly IPackageRepository _packageRepository;

        public GetAllPackagesQueryHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PackageResponse>>> Handle(GetAllPackagesQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Package> packages = await _packageRepository.GetAll();

            var packageResponses = packages.Select(package => new PackageResponse(
                    package.Id.Value,
                    package.Name,
                    package.Sku!.Value,
                    package.Description,
                    package.TravelDate.ToString("yyyy-MM-dd"),
                    new MoneyResponse(package.Price.Currency, package.Price.Amount)
                )).ToList();

            return packageResponses;
        }
    }
}
