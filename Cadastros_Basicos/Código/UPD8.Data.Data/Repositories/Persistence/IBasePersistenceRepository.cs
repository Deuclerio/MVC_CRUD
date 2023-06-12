using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Data.Repositories.Persistence
{
    public interface IBasePersistenceRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> InsertAsync(TEntity entity);
        Task InsertListAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
