using Aldebaran.Accounts;
using Aldebaran.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Aldebaran.Infrastructure.Concretes;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AldebaranContext _dbContext;

    public BaseRepository(AldebaranContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> AddAsync(TEntity entity)
    {
        var result = await _dbContext.Set<TEntity>().AddAsync(entity);

        return result.Entity.Id;
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        return Task.FromResult(entity);
    }

    public async Task<TEntity> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        
        _dbContext.Set<TEntity>().Remove(entity);

        return entity;
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return (await _dbContext.Set<TEntity>().FindAsync(id));
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}