using System.Reflection;
using Company.Product.Module.RestClient.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Module.RestClient
{
    public static class RestClientServiceCollectionExtensions
    {
        public static IServiceCollection UseRestClient(this IServiceCollection services, Func<IServiceProvider, ServiceOptions, Task<ServiceOptions>> options)
        {

            services.AddSingleton(new ServiceOptionsResolver(
                async (provider) => await options.Invoke(provider, new ServiceOptions())
            ));

            services.Scan(selector => selector
                .FromAssemblies(new List<Assembly> { typeof(RestClientServiceCollectionExtensions).Assembly })
                .AddClasses(x => x.Where(c => c.Name.EndsWith("RestService")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}
