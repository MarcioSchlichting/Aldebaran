using Aldebaran.Accounts.Models;
using Aldebaran.Domain.Repositories.Abstractions;

namespace Aldebaran.Accounts.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<bool> ExistsEmailAsync(string emailAddress);
}