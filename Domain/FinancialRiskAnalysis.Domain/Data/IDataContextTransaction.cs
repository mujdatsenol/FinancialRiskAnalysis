namespace FinancialRiskAnalysis.Domain;

public interface IDataContextTransaction : IDisposable
{
    object TransactionObject { get; }

    void Commit();

    void Rollback();
}
