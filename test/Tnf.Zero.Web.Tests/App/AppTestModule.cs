using Tnf.Zero.Application;
using Tnf.Zero.EntityFrameworkCore;
using System;
using Tnf.App.AspNetCore.TestBase;
using Tnf.App.EntityFrameworkCore;
using Tnf.Modules;

namespace Tnf.Zero.Web.Tests.App
{
    [DependsOn(
        typeof(AppModule),
        typeof(TnfAppAspNetCoreTestBaseModule))]
    public class AppTestModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration
                .TnfEfCoreInMemory(IocManager.Resolve<IServiceProvider>())
                .RegisterDbContextInMemory<TnfZeroContext>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention<AppTestModule>();
        }
    }
}
