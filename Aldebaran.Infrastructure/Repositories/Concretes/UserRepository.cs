using Aldebaran.Accounts.Models;
using Aldebaran.Accounts.Repositories;
using Aldebaran.Infrastructure.Concretes;

namespace Aldebaran.Infrastructure.Repositories.Concretes;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AldebaranContext dbContext) : base(dbContext)
    {
    }
}