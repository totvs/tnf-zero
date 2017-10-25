using Tnf.Zero.Domain;
using Tnf.Zero.EntityFrameworkCore;
using Tnf.Zero.Mapper;
using Tnf.Modules;

namespace Tnf.Zero.Application
{
    [DependsOn(
        typeof(DomainModule),
        typeof(MapperModule),
        typeof(EntityFrameworkModule))]
    public class AppModule : TnfModule
    {
        public override void Initialize()
        {
            base.Initialize();

            // Register all the interfaces and its implmentations on this assembly
            IocManager.RegisterAssemblyByConvention<AppModule>();
        }
    }
}
