using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tnf.Zero.EntityFrameworkCore
{
    public static class EntityFrameworkCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddZeroEntityFrameworkCore(this IServiceCollection services)
        {
            services
                .AddTnfEntityFrameworkCore()
                .AddTnfDbContext<ZeroContext>(config =>
                {
                    if (config.ExistingConnection != null)
                        config.DbContextOptions.UseSqlServer(config.ExistingConnection);
                    else
                        config.DbContextOptions.UseSqlServer(config.ConnectionString);
                });

            return services;
        }
    }
}