using Microsoft.EntityFrameworkCore;
using Tnf.App.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Configuration;
using Tnf.Modules;

namespace Tnf.Zero.EntityFrameworkCore
{
    [DependsOn(
        typeof(TnfAppEntityFrameworkCoreModule))]
    public class EntityFrameworkModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration
                .Modules
                .TnfEfCore()
                .AddDbContext<TnfZeroContext>(configuration =>
            {
                configuration.DbContextOptions.UseSqlServer(configuration.ConnectionString);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention<EntityFrameworkModule>();
        }
    }
}