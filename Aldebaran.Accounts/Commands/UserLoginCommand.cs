using System.ComponentModel.DataAnnotations;

namespace Aldebaran.Accounts.Commands;

public record UserLoginCommand(
    [Required] string EmailAddress,
    [Required] string Password)
{
    public string SanitizeEmailAddress() => EmailAddress
        .Trim()
        .ToLowerInvariant();
}
