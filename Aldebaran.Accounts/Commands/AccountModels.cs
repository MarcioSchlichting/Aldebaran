using System.ComponentModel.DataAnnotations;
using Aldebaran.Accounts.Models;
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

public record UserRegisterCommand(
    [Required] string EmailAddress,
    [Required] string Password,
    [Required] string Name,
    [Required] Roles Role);

public record UserRegisterResponse : BaseResponse
{
    public Guid Id { get; set; }
}

public record GetUserResponse : BaseResponse
{
    public DateTime LastLogin { get; set; }
    
    public Roles Role { get; set; }
    
    public string Name { get; set; }
    
    public string EmailAddress { get; set; }
}