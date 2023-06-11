using Aldebaran.Accounts.Models.ValueObjects;
using Aldebaran.Accounts.Validators;
using Aldebaran.Domain.Validators;

namespace Aldebaran.Accounts.Models;

public record User(
    Password Password,
    string Name,
    string EmailAddress,
    bool IsAuthenticated,
    Roles Role) : BaseEntity(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow)
{
    public DateTime LastLogin { get; set; } 
    
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