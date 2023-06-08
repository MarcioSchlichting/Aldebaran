namespace Aldebaran.Domain.Repositories.Abstractions;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<Guid> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(Guid id);

    Task<TEntity> GetByIdAsync(Guid id);
}