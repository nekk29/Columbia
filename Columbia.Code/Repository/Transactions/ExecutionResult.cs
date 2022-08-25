﻿using $safesolutionname$.Repository.Abstractions.Transactions;

namespace $safesolutionname$.Repository.Transactions
{
    public class ExecutionResult : IExecutionResult
    {
        public bool IsSuccessful { get; }

        public ExecutionResult(bool isSuccessful) => IsSuccessful = isSuccessful;
    }

    public class ExecutionResult<TResult> : ExecutionResult, IExecutionResult<TResult>
    {
        public TResult Result { get; }

        public ExecutionResult(bool isSuccessful, TResult result) : base(isSuccessful) => Result = result;
    }
}
