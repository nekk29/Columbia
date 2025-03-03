﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Module.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection UseApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationExtensions).Assembly;

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
