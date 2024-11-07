using Application.Features.Brands.Commands.Create;
using FluentValidation;

namespace Application.Features.Brands.Validations;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(cmd => cmd.Name).NotEmpty().WithMessage("Brand name cannot be empty");
        RuleFor(cmd => cmd.Name).MaximumLength(50).WithMessage("Brand name cannot be more than 50 characters");
        RuleFor(cmd => cmd.Name).MinimumLength(2).WithMessage("Brand name cannot be less than 2 characters");
    }
}