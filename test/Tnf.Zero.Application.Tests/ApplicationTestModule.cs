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
            base.PreInitialize();

            Configuration
                .TnfEfCoreInMemory()
                // The Context will be generated by the Crudzilla Tool
                .RegisterDbContextInMemory<TnfZeroContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention<ApplicationTestModule>();
        }
    }
}