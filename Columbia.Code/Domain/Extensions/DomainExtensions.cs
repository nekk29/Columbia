using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace $safesolutionname$.Domain.Extensions
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection UseDomainServices(this IServiceCollection services)
        {
            var assembly = typeof(DomainServiceCollectionExtensions).Assembly;

            // Domain Validators
            services.Scan(selector => selector
                .FromAssemblies(new List<Assembly> { assembly })
                .AddClasses(x => x.Where(c => c.Name.EndsWith("Validator")))
                .AsSelf()
                .WithScopedLifetime()
            );

            // MediatR Command and Queries
            services.AddMediatR(options => options.RegisterServicesFromAssembly(assembly));

            // AutoMapper Configuration
            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
