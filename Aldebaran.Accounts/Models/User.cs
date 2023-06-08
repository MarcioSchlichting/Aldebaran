using Aldebaran.Accounts.Models.ValueObjects;

namespace Aldebaran.Accounts.Models;

public record User(
    Password Password, 
    string Name, 
    string EmailAddress,
    bool IsAutenticated,
    DateTime LastLogin) : BaseEntity(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow);