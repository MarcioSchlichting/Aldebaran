using Aldebaran.Accounts.Models;
using Aldebaran.Domain.Repositories.Abstractions;
using Aldebaran.Domain.Repositories.Models;
using Aldebaran.Infrastructure.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Aldebaran.Infrastructure.Repositories.Concretes;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AldebaranContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> ExistsEmailAsync(string emailAddress)
    {
        return await _dbContext
            .Set<User>()
            .AnyAsync(u => u.EmailAddress == emailAddress);
    }
    
    public async Task<UserInfo> GetUserInfoAsync(string emailAddress)
    {
        var user = await _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
        
        return new UserInfo(user!.Name, user.Role);
    }

    public async Task<bool> AlreadyExistsAsync(User user)
    {
        return await _dbContext
            .Set<User>()
            .AnyAsync(u =>
                u.EmailAddress == user.EmailAddress ||
                u.Password == user.Password ||
                u.Name == user.Name);
    }
}