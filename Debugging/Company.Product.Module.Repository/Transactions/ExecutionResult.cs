using Company.Product.Module.Repository.Abstractions.Transactions;

namespace Company.Product.Module.Repository.Transactions
{
    public class ExecutionResult(bool isSuccessful) : IExecutionResult
    {
        public bool IsSuccessful { get; } = isSuccessful;
    }

    public class ExecutionResult<TResult>(bool isSuccessful, TResult result) : ExecutionResult(isSuccessful), IExecutionResult<TResult>
    {
        public TResult Result { get; } = result;
    }
}
