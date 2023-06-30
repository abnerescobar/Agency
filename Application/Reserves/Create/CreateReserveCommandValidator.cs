using FluentValidation;

namespace Application.Reserves.Create
{
    public class CreateReserveCommandValidator : AbstractValidator<CreateReserveCommand>
    {
        public CreateReserveCommandValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(command => command.Packages).NotEmpty().WithMessage("Packages are required.");
            RuleForEach(command => command.Packages)
                .ChildRules(package =>
                {
                    package.RuleFor(p => p.PackageId).NotEmpty().WithMessage("PackageId is required.");
                    package.RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
                });
        }
    }
}
