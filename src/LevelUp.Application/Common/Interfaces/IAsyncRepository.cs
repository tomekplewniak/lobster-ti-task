using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace LevelUp.Application.Common.Interfaces;

public interface IAsyncRepository<TEntity>
    where TEntity : class
{
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void Delete(object id);

    void Delete(TEntity entity);

    void Detach(TEntity entity);

    Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);

    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);

    Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> selector = default);
}
