using Application.Packages.Common;
using Domain.Packages;
using Domain.Primitives;

using Domain.ValueObjects;
using ErrorOr;
using MediatR;
namespace Application.Packages.Create;

internal class CreatePackageCommandHandler: IRequestHandler<CreatePackageCommand, ErrorOr<PackageResponse>>
{
    private readonly IPackageRepository _packageRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreatePackageCommandHandler(
        IPackageRepository repository,
        IUnitOfWork unitOfWork)
    {
        _packageRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<PackageResponse>> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
    {
        var package = new Package(
            new PackageId(Guid.NewGuid()),
            Sku.Create(request.Sku)!,
            request.Name,
            request.Description,
            DateTime.UtcNow,
            new Money(request.Currency, request.Amount));
        _packageRepository.Add(package);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new PackageResponse();
    }
}
