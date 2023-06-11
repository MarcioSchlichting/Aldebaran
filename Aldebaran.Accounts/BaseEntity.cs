using Aldebaran.Domain.Validators;

namespace Aldebaran.Accounts;

public interface IValidator
{
    ValidatorResult Validate();
}

public abstract record BaseEntity(Guid Id, DateTime CreatedAt, DateTime UpdatedAt) : IValidator
{
    public abstract ValidatorResult Validate();
}