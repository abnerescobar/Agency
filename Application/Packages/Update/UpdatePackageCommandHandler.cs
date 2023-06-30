using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Packages.Update;
using Domain.Packages;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Packages.Update
{
    internal sealed class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommand, ErrorOr<Unit>>
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePackageCommandHandler(IPackageRepository packageRepository, IUnitOfWork unitOfWork)
        {
            _packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdatePackageCommand command, CancellationToken cancellationToken)
        {
            if (!await _packageRepository.ExistsAsync(new PackageId(command.Id)))
            {
                return Error.NotFound("Package.NotFound", "The package with the provided Id was not found.");
            }

            if (!DateTime.TryParseExact(command.TravelDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime travelDate))
            {
                return Error.Validation("Package.TravelDate", "Invalid travel date format.");
            }


            Money price = new Money(command.Money.Currency, command.Money.Amount);

            Package package = new Package(
                new PackageId(command.Id),
                Sku.Create(command.Sku) ?? throw new ArgumentNullException("Package.Sku", "Invalid SKU format."),
                command.Name,
                command.Description,
                travelDate,
                price
            );

            _packageRepository.Update(package);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
