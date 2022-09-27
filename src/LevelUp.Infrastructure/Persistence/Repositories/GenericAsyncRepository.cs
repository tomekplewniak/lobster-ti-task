using System.Linq.Expressions;
using LevelUp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace LevelUp.Infrastructure.Persistence.Repositories;
public class GenericAsyncRepository<TEntity> : IAsyncRepository<TEntity>
       where TEntity : class
{
    private readonly ApplicationDbContext _context;

    protected DbSet<TEntity> DbSet { get; }

    protected internal GenericAsyncRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public virtual async ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await DbSet.AddAsync(entity, cancellationToken);

    public virtual async Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
        await DbSet.AddRangeAsync(entities, cancellationToken);

    public void Detach(TEntity entity) =>
        _context.Entry(entity).State = EntityState.Detached;

    public virtual void Update(TEntity entity) => DbSet.Update(entity);

    public virtual void Delete(TEntity entity) => DbSet.Remove(entity);

    public virtual void Delete(object id)
    {
        var entity = DbSet.Find(id);
        if (entity is { })
            Delete(entity);
        else
            throw new KeyNotFoundException($"Cannot delete item with key value {id} because it does not exist.");
    }

    public virtual async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        var query = DbSet as IQueryable<TEntity>;

        if (disableTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        if (predicate is { })
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return orderBy switch
        {
            { } => await orderBy(query).ToListAsync(),
            _ => await query.ToListAsync()
        };
    }

    public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        var query = DbSet as IQueryable<TEntity>;

        if (disableTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        if (predicate is { })
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        if (orderBy is { })
            return await orderBy(query).FirstOrDefaultAsync();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        var query = DbSet as IQueryable<TEntity>;

        if (disableTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        if (predicate is { })
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return await query.SingleOrDefaultAsync();
    }

    public virtual Task<bool> ExistsAsync() => ExistsAsync(default);

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> selector) =>
        selector switch
        {
            null => await DbSet.AnyAsync(),
            _ => await DbSet.AnyAsync(selector)
        };
}