using Company.Product.Module.Repository.Abstractions.Base;
using Company.Product.Module.Repository.Abstractions.Transactions;
using Company.Product.Module.Repository.Base;
using Company.Product.Module.Repository.Data;
using Company.Product.Module.Repository.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Module.Repository.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddSqlServer<CoreDbContext>(connectionString, b => b.MigrationsAssembly("Company.Product.Module.Apis"));

            services.AddScoped<DbContext, CoreDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.Scan(selector => selector
                .FromAssemblies(typeof(RepositoryServiceCollectionExtensions).Assembly)
                .AddClasses(x => x.Where(c => c.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
            );

            return services;
        }
    }
}
