﻿namespace $safesolutionname$.Repository.Abstractions.Transactions
{
    public interface IExecutionResult
    {
        bool IsSuccessful { get; }
    }

    public interface IExecutionResult<TResult> : IExecutionResult
    {
        TResult Result { get; }
    }
}
