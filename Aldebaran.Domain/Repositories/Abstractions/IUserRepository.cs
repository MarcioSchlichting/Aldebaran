using Aldebaran.Accounts.Models;
using Aldebaran.Domain.Repositories.Models;

namespace Aldebaran.Domain.Repositories.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> ExistsEmailAsync(string emailAddress);

    Task<UserInfo> GetUserInfoAsync(string emailAddress);

    Task<bool> AlreadyExistsAsync(User user);
}