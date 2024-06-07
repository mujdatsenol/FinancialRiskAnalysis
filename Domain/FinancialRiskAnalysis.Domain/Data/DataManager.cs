using Microsoft.Extensions.DependencyInjection;

namespace FinancialRiskAnalysis.Domain;

public class DataManager : IDataManager
{
    private readonly IServiceProvider serviceProvider;
    private readonly IList<IUnitOfWork> unitOfWorks;

    public DataManager(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.unitOfWorks = new List<IUnitOfWork>();
    }

    public IUnitOfWork CreateUnitOfWork(ScopeType scopeType = ScopeType.Default)
    {
        return this.serviceProvider.GetService<IUnitOfWork>();
    }

    public void PushUnitOfWork(IUnitOfWork unitOfWork)
    {
        this.unitOfWorks.Add(unitOfWork);
    }

    public void PopUnitOfWork(IUnitOfWork unitOfWork)
    {
        var last = this.PeekUnitOfWork();

        if (last != unitOfWork)
        {
            throw new InvalidOperationException("The referenced unit of work object is not the latest one in the stack.");
        }

        this.unitOfWorks.Remove(unitOfWork);
    }

    public IUnitOfWork PeekUnitOfWork()
    {
        return this.unitOfWorks.LastOrDefault();
    }

    public T GetRepository<T>()
        where T : class, IRepository
    {
        return this.serviceProvider.GetService<T>();
    }
}
