using FinancialRiskAnalysis.Domain.Contract.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FinancialRiskAnalysis.Domain;

public partial class GenericRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    private readonly IDataContext dataContext;
    private readonly IDataManager dataManager;

    public GenericRepository(IDataManager dataManager, IDataContext dataContext)
    {
        this.dataManager = dataManager;
        this.dataContext = dataContext;
    }

    public IDataContext DataContext
    {
        get
        {
            var activeDataContext = this.GetActiveDataContext();
            return activeDataContext.dataContext;
        }
    }

    #region Command

    public virtual async Task AddAsync(T entity, CancellationToken token = default)
    {
        var result = this.GetDbSet();

        await result.dbSet.AddAsync(entity, token).ConfigureAwait(false);

        if (!result.isUow)
        {
            await result.dataContext.SaveChangesAsync(token).ConfigureAwait(false);
        }
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken token = default)
    {
        var result = this.GetDbSet();

        await result.dbSet.AddRangeAsync(entities, token).ConfigureAwait(false);

        if (!result.isUow)
        {
            await result.dataContext.SaveChangesAsync(token).ConfigureAwait(false);
        }
    }

    public virtual void Delete(T entity)
    {
        var result = this.GetDbSet();

        result.dbSet.Remove(entity);

        if (!result.isUow)
        {
            result.dataContext.SaveChangesAsync();
        }
    }

    public virtual Task DeleteAsync(T entity, CancellationToken token = default)
    {
        return Task.Run(() => { this.Delete(entity); }, token);
    }

    public virtual void Update(T entity)
    {
        var result = this.GetDbSet();

        var state = result.dataContext.GetEntryState(entity);

        if (state != ContextEntityState.Added)
        {
            result.dbSet.Update(entity);
        }

        if (!result.isUow)
        {
            result.dataContext.SaveChangesAsync();
        }
    }

    public virtual Task UpdateAsync(T entity, CancellationToken token = default)
    {
        return Task.Run(() => { this.Update(entity); }, token);
    }

    #endregion Command

    #region Query

    public virtual async Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true)
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null
            ? await orderBy(query).FirstOrDefaultAsync()
            : await query.FirstOrDefaultAsync();
    }

    public virtual async Task<TResult?> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true)
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null
            ? await orderBy(query).Select(selector).FirstOrDefaultAsync()
            : await query.Select(selector).FirstOrDefaultAsync();
    }

    public virtual Task<List<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true,
        CancellationToken cancellationToken = default)
    {
        return this.GetQueryable(predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToListAsync(cancellationToken);
    }

    public virtual Task<List<TResult>> GetListAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true,
        CancellationToken cancellationToken = default)
        where TResult : class
    {
        return this.GetQueryable(selector: selector, predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToListAsync(cancellationToken);
    }

    public virtual Task<IPagedList<T>> GetPagedListAsync(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        int pageIndex = 0,
        int pageSize = 20,
        int indexFrom = 0,
        bool disableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null
            ? orderBy(query).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken)
            : query.ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken);
    }

    public virtual Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        int pageIndex = 0,
        int pageSize = 20,
        int indexFrom = 0,
        bool disableTracking = true,
        CancellationToken cancellationToken = default)
        where TResult : class
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null
            ? orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken)
            : query.Select(selector).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken);
    }

    public virtual IQueryable<T> GetQueryable(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true)
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null ? orderBy(query) : query;
    }

    public virtual IQueryable<TResult> GetQueryable<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true)
        where TResult : class
    {
        IQueryable<T> query = this.GetDbSetByQuery().dbSet;
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return orderBy != null ? orderBy(query).Select(selector) : query.Select(selector);
    }

    #endregion Query

    #region Helper Methods

    public (IDataContext dataContext, bool isUow, IQueryable<T> dbSet) GetDbSetByQuery(bool disableTracking = false)
    {
        var result = this.GetDbSet();

        IQueryable<T>? dbset = disableTracking ? result.dbSet.AsNoTracking() : result.dbSet;

        return (result.dataContext, result.isUow, dbset);
    }

    protected (IDataContext dataContext, bool isUow) GetActiveDataContext()
    {
        var uow = this.dataManager.PeekUnitOfWork();

        if (uow == null)
        {
            return (this.dataContext, false);
        }

        var currentDataContext = uow.GetDataContext(this.dataContext);

        return (currentDataContext, true);
    }

    protected (IDataContext dataContext, bool isUow, DbContext dbContext) GetDbContext()
    {
        var result = this.GetActiveDataContext();

        var dbContext = result.dataContext.ContextObject as DbContext;

        return (result.dataContext, result.isUow, dbContext);
    }

    protected (IDataContext dataContext, bool isUow, DbSet<T> dbSet) GetDbSet()
    {
        var result = this.GetDbContext();

        var dbSet = result.dbContext.Set<T>();

        return (result.dataContext, result.isUow, dbSet);
    }

    #endregion Helper Methods
}
