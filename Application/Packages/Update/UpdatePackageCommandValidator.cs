using Application.Packages.Update;
using FluentValidation;

namespace Application.Packages.Update
{
    public class UpdatePackageCommandValidator : AbstractValidator<UpdatePackageCommand>
    {
        public UpdatePackageCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Name).NotEmpty().MaximumLength(100);
            RuleFor(r => r.Description).NotEmpty().MaximumLength(500);
            RuleFor(r => r.Sku).NotEmpty().MaximumLength(50);
            RuleFor(r => r.TravelDate).NotEmpty().Matches(@"^\d{4}-\d{2}-\d{2}$").WithMessage("Invalid travel date format. The expected format is 'yyyy-MM-dd'.");
            RuleFor(r => r.Money).NotNull().SetValidator(new UpdateMoneyValidator());
        }
    }

    public class UpdateMoneyValidator : AbstractValidator<UpdateMoney>
    {
        public UpdateMoneyValidator()
        {
            RuleFor(r => r.Currency).NotEmpty().MaximumLength(3);
            RuleFor(r => r.Amount).NotEmpty().GreaterThan(0);
        }
    }
}
