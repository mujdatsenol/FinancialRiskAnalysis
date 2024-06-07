namespace FinancialRiskAnalysis.Domain;

public interface IDataContext
{
    object ContextObject { get; }

    IDataContext NewContext();

    Task<IDataContextTransaction> BeginTransactionAsync(CancellationToken token = default);

    ContextEntityState GetEntryState<TEntity>(TEntity entity)
        where TEntity : class;

    void SetEntryState<TEntity>(TEntity entity, ContextEntityState state)
        where TEntity : class;

    Task SaveChangesAsync(CancellationToken token = default);
}
