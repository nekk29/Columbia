using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using $safesolutionname$.Repository.Abstractions.Base;
using $safesolutionname$.Repository.Abstractions.Transactions;
using $safesolutionname$.Repository.Base;
using $safesolutionname$.Repository.Data;
using $safesolutionname$.Repository.Transactions;

namespace $safesolutionname$.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services, IConfiguration configuration, string migrationsAssembly)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddSqlServer<CoreDbContext>(connectionString, b => b.MigrationsAssembly(migrationsAssembly));

            services.AddScoped<DbContext, CoreDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.Scan(selector => selector
                .FromAssemblies(typeof(RepositoryExtensions).Assembly)
                .AddClasses(x => x.Where(c => c.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
            );

            return services;
        }
    }
}
