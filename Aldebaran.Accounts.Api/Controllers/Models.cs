namespace Aldebaran.Accounts.Api.Controllers;

public record UserLoginCommand(
    string EmailAddress,
    string Password);