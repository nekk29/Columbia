namespace $safesolutionname$.RestClient.Base
{
    internal class ServiceOptionsResolver
    {
        private readonly Func<IServiceProvider, Task<ServiceOptions>> _configure;
        public ServiceOptionsResolver(Func<IServiceProvider, Task<ServiceOptions>> configure) => _configure = configure;
        public async Task<ServiceOptions> GetOptions(IServiceProvider serviceProvider) => await _configure.Invoke(serviceProvider);
    }
}
