using Aldebaran.Accounts;
using Aldebaran.Domain;
using Aldebaran.Domain.Repositories.Abstractions;
using Aldebaran.Infrastructure.Concretes;
using Aldebaran.Infrastructure.Repositories.Concretes;
using Aldebaran.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aldebaran.Infrastructure;

public static class AldebaranModules
{
    public static void AddRepositories(this IServiceCollection services, Options options)
    {
        services.AddDbContext<AldebaranContext>(x => x.UseSqlServer(options.ConnectionString));
        
        services.AddTransient<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
        services.AddTransient<IUserRepository, UserRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IJwtGeneratorService, JwtGeneratorService>();
    }
}