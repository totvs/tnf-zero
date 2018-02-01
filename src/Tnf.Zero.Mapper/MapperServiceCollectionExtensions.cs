using Microsoft.Extensions.DependencyInjection;

namespace Tnf.Zero.Mapper
{
    public static class MapperServiceCollectionExtensions
    {
        public static IServiceCollection AddZeroMapper(this IServiceCollection services)
        {
            services.AddTnfAutoMapper(config =>
            {
                config.AddProfile(new DomainToDtoProfile());
            });

            return services;
        }
    }
}
