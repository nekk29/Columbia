﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace $safesolutionname$.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection UseApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationServiceCollectionExtensions).Assembly;

            // Application
            services.Scan(selector => selector
                .FromAssemblies(new List<Assembly> { assembly })
                .AddClasses(x => x.Where(c => c.Name.EndsWith("Application")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}
