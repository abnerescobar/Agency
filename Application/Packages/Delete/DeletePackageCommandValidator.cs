using FluentValidation;

namespace Application.Packages.Delete
{
    public class DeletePackageCommandValidator : AbstractValidator<DeletePackageCommand>
    {
        public DeletePackageCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}
