using Tnf.Zero.EntityFrameworkCore;
using Tnf.Zero.Mapper;
using Tnf.App.EntityFrameworkCore;
using Tnf.App.TestBase;
using Tnf.Modules;

namespace Tnf.Zero.Domain.Tests.App
{
    [DependsOn(
        typeof(DomainModule),
        typeof(MapperModule),
        typeof(EntityFrameworkModule),
        typeof(TnfAppTestBaseModule))]
    public class DomainTestModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration
                .TnfEfCoreInMemory()
                .RegisterDbContextInMemory<TnfZeroContext>();
        }

        public override void Initialize()
        {
            base.Initialize();

            IocManager.RegisterAssemblyByConvention<DomainTestModule>();
        }
    }
}
