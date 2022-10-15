using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Core.Common.Persistence;
using Restaurants.Core.Domain.Common;
using Restaurants.Infra.Persistence;
using Restaurants.Infra.Persistence.Context;
using Restaurants.Infra.Persistence.Repository;
using System.Reflection;

namespace Restaurants.Infra
{
    public static class Startup
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddPersistence(config);
        }

        internal static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var databaseSettings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            if (string.IsNullOrEmpty(databaseSettings?.ConnectionString))
                throw new InvalidOperationException("DB ConnectionString is not configured.");

            return services
                .Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)))
                .AddDbContext<ApplicationDbContext>(m => m.UseSqlServer(databaseSettings.ConnectionString))
                .AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add Repositories
            services.AddScoped(typeof(IRepository<>), typeof(ApplicationDbRepository<>));

            foreach (var aggregateRootType in
                typeof(IAggregateRoot).Assembly.GetExportedTypes()
                    .Where(t => typeof(IAggregateRoot).IsAssignableFrom(t) && t.IsClass)
                    .ToList())
            {
                // Add ReadRepositories.
                services.AddScoped(typeof(IReadRepository<>).MakeGenericType(aggregateRootType), sp =>
                    sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)));
            }

            return services;
        }
    }
}