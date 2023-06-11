using Aldebaran.Accounts.Validators;
using Aldebaran.Domain.Validators;

namespace Aldebaran.Accounts.Models;

public record User(
    string Password,
    string Name,
    string EmailAddress,
    bool IsAuthenticated,
    Roles Role,
    DateTime LastLogin) : BaseEntity(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow)
{
    public override ValidatorResult Validate()
    {
        var validator = new UserValidator();
        var result = validator.Validate(this);

        return new ValidatorResult(
            result.IsValid, 
            result.Errors
                .Select(x => x.ErrorMessage)
                .ToList());
    }
}