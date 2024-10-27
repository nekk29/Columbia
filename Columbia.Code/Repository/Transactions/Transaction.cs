using Microsoft.EntityFrameworkCore.Storage;
using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Repository.Transactions
{
    public class Transaction(IDbContextTransaction dbContextTransaction) : ITransaction, IDisposable
    {
        public Guid TransactionId => dbContextTransaction?.TransactionId ?? default;

        public void Commit() =>
            dbContextTransaction.Commit();

        public async Task CommitAsync(CancellationToken cancellationToken = default)
            => await dbContextTransaction.CommitAsync(cancellationToken);

        public void Rollback()
            => dbContextTransaction.Rollback();

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
            => await dbContextTransaction.RollbackAsync(cancellationToken);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
