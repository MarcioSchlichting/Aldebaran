using Aldebaran.Accounts.Models;

namespace Aldebaran.Domain.Repositories.Models;

public sealed record UserInfo(string Name, Roles Role);