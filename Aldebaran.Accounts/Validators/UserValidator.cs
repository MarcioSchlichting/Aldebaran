using Aldebaran.Accounts.Models;
using Aldebaran.Accounts.Shared;
using FluentValidation;

namespace Aldebaran.Accounts.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(Constants.Name.MaxLength)
            .MinimumLength(Constants.Name.MinLength);
        
        RuleFor(x => x.EmailAddress)
            .NotNull()
            .NotEmpty()
            .EmailAddress();
        
        RuleFor<string>(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8);
    }
}