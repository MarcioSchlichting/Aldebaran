namespace Aldebaran.Api.Controllers;

public record UserLoginCommand(
    string EmailAddress, 
    string Password);