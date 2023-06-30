using FluentValidation;

namespace Application.Customers.Delete;

public class DeletePackageCommandValidator : AbstractValidator<DeletePackageCommand>
{
    public DeletePackageCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}