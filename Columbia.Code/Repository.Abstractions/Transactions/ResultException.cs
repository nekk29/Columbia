namespace $safesolutionname$.Repository.Abstractions.Transactions
{
    public class ResultException<TResult>(TResult result) : Exception
    {
        public TResult Result { get; set; } = result;
    }
}
