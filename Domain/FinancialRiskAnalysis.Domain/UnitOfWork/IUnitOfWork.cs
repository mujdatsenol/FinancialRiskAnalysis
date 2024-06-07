namespace FinancialRiskAnalysis.Domain;

public interface IUnitOfWork : IDisposable
{
    ScopeType ScopeType { get; set; }

    IDataContext GetDataContext(IDataContext dataContext);

    Task SaveChangesAsync(CancellationToken token = default);
}
