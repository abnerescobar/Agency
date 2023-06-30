using FluentValidation;

namespace Application.Packages.Create
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(command => command.Description).NotEmpty().WithMessage("La descripción es obligatoria.");
            RuleFor(command => command.Sku).NotEmpty().WithMessage("El SKU es obligatorio.");
            RuleFor(command => command.TravelDate).NotEmpty().WithMessage("La fecha de viaje es obligatoria.");
            RuleFor(command => command.Currency).NotEmpty().WithMessage("La moneda es obligatoria.");
            RuleFor(command => command.Amount).GreaterThan(0).WithMessage("El monto debe ser mayor que cero.");
        }
    }
}
