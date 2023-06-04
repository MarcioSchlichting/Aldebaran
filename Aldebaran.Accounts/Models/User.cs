namespace Aldebaran.Accounts.Models;

public record User(
    string Password, 
    string Name, 
    string EmailAddress,
    bool IsAutenticated,
    DateTime LastLogin) : BaseEntity(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow);