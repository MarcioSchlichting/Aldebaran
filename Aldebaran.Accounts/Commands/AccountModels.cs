using System.ComponentModel.DataAnnotations;
using Aldebaran.Domain.ApiResponses;

namespace Aldebaran.Accounts.Commands;

public record UserLoginCommand(
    [Required] string EmailAddress,
    [Required] string Password)
{
    public string SanitizeEmailAddress() => EmailAddress
        .Trim()
        .ToLowerInvariant();
}

public record UserLoginResponse : BaseResponse
{
    public string Token { get; set; }
}