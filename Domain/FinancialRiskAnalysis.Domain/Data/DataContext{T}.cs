using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialRiskAnalysis.Domain;

public class DataContext<T> : IDataContext
    where T : DbContext
{
    private readonly IServiceProvider serviceProvider;
    private readonly T dbContext;

    public DataContext(IServiceProvider serviceProvider, T dbContext)
    {
        this.serviceProvider = serviceProvider;
        this.dbContext = dbContext;
    }

    public object ContextObject
    {
        get => this.dbContext;
    }

    public IDataContext NewContext()
    {
        var newContext = this.serviceProvider.GetService<T>();
        return new DataContext<T>(this.serviceProvider, newContext);
    }

    public async Task<IDataContextTransaction> BeginTransactionAsync(CancellationToken token = default)
    {
        var transaction = await this.dbContext.Database.BeginTransactionAsync(token).ConfigureAwait(false);

        return new DataContextTransaction(transaction);
    }

    public ContextEntityState GetEntryState<TEntity>(TEntity entity)
            where TEntity : class
    {
        var entityState = this.dbContext.Entry(entity).State;

        if (entityState == EntityState.Detached)
        {
            return ContextEntityState.Detached;
        }

        if (entityState == EntityState.Unchanged)
        {
            return ContextEntityState.Unchanged;
        }

        if (entityState == EntityState.Deleted)
        {
            return ContextEntityState.Deleted;
        }

        if (entityState == EntityState.Modified)
        {
            return ContextEntityState.Modified;
        }

        if (entityState == EntityState.Added)
        {
            return ContextEntityState.Added;
        }

        return ContextEntityState.Unknown;
    }

    public void SetEntryState<TEntity>(TEntity entity, ContextEntityState state)
            where TEntity : class
    {
        var entry = this.dbContext.Entry(entity);

        if (state == ContextEntityState.Detached)
        {
            entry.State = EntityState.Detached;
        }

        if (state == ContextEntityState.Unchanged)
        {
            entry.State = EntityState.Unchanged;
        }

        if (state == ContextEntityState.Deleted)
        {
            entry.State = EntityState.Deleted;
        }

        if (state == ContextEntityState.Modified)
        {
            entry.State = EntityState.Modified;
        }

        if (state == ContextEntityState.Added)
        {
            entry.State = EntityState.Added;
        }
    }

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        if (!this.dbContext.ChangeTracker.HasChanges())
        {
            return;
        }

        await this.dbContext.SaveChangesAsync(token).ConfigureAwait(false);
    }
}
