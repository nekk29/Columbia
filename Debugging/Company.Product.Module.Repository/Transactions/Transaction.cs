﻿using Company.Product.Module.Repository.Abstractions.Transactions;
using Microsoft.EntityFrameworkCore.Storage;

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
namespace Company.Product.Module.Repository.Transactions
{
    public class Transaction : ITransaction, IDisposable
    {
        public Guid TransactionId => _dbContextTransaction?.TransactionId ?? default;

        private readonly IDbContextTransaction _dbContextTransaction;

        public Transaction(IDbContextTransaction dbContextTransaction)
            => _dbContextTransaction = dbContextTransaction;

        public void Commit() =>
            _dbContextTransaction.Commit();

        public async Task CommitAsync(CancellationToken cancellationToken = default)
            => await _dbContextTransaction.CommitAsync(cancellationToken);

        public void Rollback()
            => _dbContextTransaction.Rollback();

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
            => await _dbContextTransaction.RollbackAsync(cancellationToken);

        public void Dispose()
            => _dbContextTransaction.Dispose();
    }
}
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
