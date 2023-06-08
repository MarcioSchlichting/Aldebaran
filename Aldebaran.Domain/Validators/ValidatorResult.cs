namespace Aldebaran.Domain.Validators;

public record ValidatorResult(bool IsValid, IReadOnlyList<string> Errors);