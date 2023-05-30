using Microsoft.Extensions.DependencyInjection;
using $safesolutionname$.RestClient.Base;
using System.Reflection;

namespace $safesolutionname$.RestClient
{
    public static class RestClientServiceCollectionExensions
    {
        public static IServiceCollection UseRestClient(this IServiceCollection services, Func<IServiceProvider, ServiceOptions, Task<ServiceOptions>> options)
        {

            services.AddSingleton(new ServiceOptionsResolver(
                async (provider) => await options.Invoke(provider, new ServiceOptions())
            ));

            services.Scan(selector => selector
                .FromAssemblies(new List<Assembly> { typeof(RestClientServiceCollectionExensions).Assembly })
                .AddClasses(x => x.Where(c => c.Name.EndsWith("RestService")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}
