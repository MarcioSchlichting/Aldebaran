using System.ComponentModel.DataAnnotations;

namespace Aldebaran.Accounts.Api.Controllers;

public record UserLoginCommand(
    [Required] string EmailAddress,
    [Required] string Password)
{
    public string SanitizeEmailAddress() => EmailAddress
        .Trim()
        .ToLowerInvariant();
}

public record UserLoginResponse(string AuthorizationToken);