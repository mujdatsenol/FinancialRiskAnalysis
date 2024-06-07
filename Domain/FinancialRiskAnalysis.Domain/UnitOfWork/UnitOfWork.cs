using System.Data;

namespace FinancialRiskAnalysis.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataManager dataManager;

    private ScopeType scopeType;

    private IsolationLevel isolationLevel;

    private IDictionary<Type, IDataContext>? dataContexts;

    private bool isSaveChangesCalled;

    private volatile bool isDisposed;

    public UnitOfWork(IDataManager dataManager, ScopeType scopeType = ScopeType.Default)
    {
        this.dataManager = dataManager;
        this.scopeType = scopeType;
        this.dataContexts = new Dictionary<Type, IDataContext>();
        this.isSaveChangesCalled = false;
        this.isDisposed = false;

        this.dataManager.PushUnitOfWork(this);
    }

    ~UnitOfWork()
    {
        this.Dispose(false);
    }

    public ScopeType ScopeType
    {
        get => this.scopeType;
        set => this.scopeType = value;
    }

    public IDataContext GetDataContext(IDataContext dataContext)
    {
        var dbContextType = dataContext.ContextObject.GetType();

        if (!this.dataContexts.ContainsKey(dbContextType))
        {
            var newContext = dataContext.NewContext();

            this.dataContexts.Add(dbContextType, newContext);
        }

        return this.dataContexts[dbContextType];
    }

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        this.CheckDisposed();
        this.CheckSaveChangesCalledPreviously();

        var transactions = new List<IDataContextTransaction>();

        foreach (var dataContext in this.dataContexts.Values)
        {
            var transaction = await dataContext.BeginTransactionAsync(token).ConfigureAwait(false);

            transactions.Add(transaction);
        }

        foreach (var dbContext in this.dataContexts.Values)
        {
            await dbContext.SaveChangesAsync(token).ConfigureAwait(false);
        }

        foreach (var transaction in transactions)
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }


        this.dataContexts.Clear();
        this.isSaveChangesCalled = true;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void CheckDisposed()
    {
        if (this.isDisposed)
        {
            throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
        }
    }

    protected void CheckSaveChangesCalledPreviously()
    {
        if (this.isSaveChangesCalled)
        {
            throw new ObjectDisposedException("The UnitOfWork is already called save changes method and cannot be used anymore.");
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.isDisposed)
        {
            return;
        }

        this.isDisposed = true;

        if (disposing)
        {
            this.dataManager.PopUnitOfWork(this);

            this.dataContexts = null;
        }
    }
}
