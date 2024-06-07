using FinancialRiskAnalysis.Domain.Contract.PagedList;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FinancialRiskAnalysis.Domain;

public interface IRepository<T> : IRepository
    where T : class, IEntity
{
    #region Command

    IDataContext DataContext { get; }

    Task AddAsync(T entity, CancellationToken token = default);

    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken token = default);

    Task DeleteAsync(T entity, CancellationToken token = default);

    Task UpdateAsync(T entity, CancellationToken token = default);

    (IDataContext dataContext, bool isUow, IQueryable<T> dbSet) GetDbSetByQuery(bool disableTracking = false);

    #endregion Command

    #region Query

    Task<T> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true);

    Task<TResult> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true);

    Task<List<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true,
        CancellationToken cancellationToken = default);

    Task<List<TResult>> GetListAsync<TResult>(
          Expression<Func<T, TResult>> selector,
          Expression<Func<T, bool>>? predicate,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
          bool disableTracking = true,
          CancellationToken cancellationToken = default)
        where TResult : class;

    Task<IPagedList<T>> GetPagedListAsync(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        int pageIndex = 0,
        int pageSize = 10,
        int indexFrom = 0,
        bool disableTracking = true,
        CancellationToken cancellationToken = default);

    Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        int pageIndex = 0,
        int pageSize = 10,
        int indexFrom = 0,
        bool disableTracking = true,
        CancellationToken cancellationToken = default)
        where TResult : class;

    IQueryable<T> GetQueryable(
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true);

    IQueryable<TResult> GetQueryable<TResult>(
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
        bool disableTracking = true)
        where TResult : class;

    #endregion Query
}
