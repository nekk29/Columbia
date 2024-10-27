namespace $safesolutionname$.RestClient.Base
{
    internal class ServiceOptionsResolver(Func<IServiceProvider, Task<ServiceOptions>> configure)
    {
        public async Task<ServiceOptions> GetOptions(IServiceProvider serviceProvider) => await configure.Invoke(serviceProvider);
    }
}
