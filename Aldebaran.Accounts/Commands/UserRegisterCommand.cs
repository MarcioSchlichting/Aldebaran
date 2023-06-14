using System.ComponentModel.DataAnnotations;
using Aldebaran.Accounts.Models;

namespace Aldebaran.Accounts.Commands;

public record UserRegisterCommand(
    [Required] string EmailAddress,
    [Required] string Password,
    [Required] string Name,
    [Required] Roles Role);