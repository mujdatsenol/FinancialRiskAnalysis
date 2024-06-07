using Microsoft.EntityFrameworkCore.Storage;

namespace FinancialRiskAnalysis.Domain;

public class DataContextTransaction : IDataContextTransaction
{

    private readonly IDbContextTransaction transaction;
    private volatile bool isDisposed;

    public DataContextTransaction(IDbContextTransaction transaction)
    {
        this.transaction = transaction;
        this.isDisposed = false;
    }

    ~DataContextTransaction()
    {
        this.Dispose(false);
    }

    public object TransactionObject
    {
        get => this.transaction;
    }

    public void Commit()
    {
        this.CheckDisposed();

        this.transaction.Commit();
    }

    public void Rollback()
    {
        this.CheckDisposed();

        this.transaction.Rollback();
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
            throw new ObjectDisposedException("The DataContextTransaction is already disposed and cannot be used anymore.");
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
            this.transaction.Dispose();
        }
    }
}
