using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Repository.Transactions
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
