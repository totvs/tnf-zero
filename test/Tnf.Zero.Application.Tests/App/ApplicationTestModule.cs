using Tnf.Zero.EntityFrameworkCore;
using Tnf.App.EntityFrameworkCore;
using Tnf.App.TestBase;
using Tnf.Modules;

namespace Tnf.Zero.Application.Tests.App
{
    [DependsOn(
        typeof(AppModule),
        typeof(TnfAppTestBaseModule))]
    public class ApplicationTestModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration
                .TnfEfCoreInMemory()
                .RegisterDbContextInMemory<TnfZeroContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention<ApplicationTestModule>();
        }
    }
}