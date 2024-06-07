namespace FinancialRiskAnalysis.Domain;

public interface IDataManager
{
    IUnitOfWork CreateUnitOfWork(ScopeType scopeType = ScopeType.Default);

    void PushUnitOfWork(IUnitOfWork unitOfWork);

    void PopUnitOfWork(IUnitOfWork unitOfWork);

    IUnitOfWork PeekUnitOfWork();

    T GetRepository<T>()
        where T : class, IRepository;
}
