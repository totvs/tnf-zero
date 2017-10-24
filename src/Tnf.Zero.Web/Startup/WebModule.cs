using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Tnf.App.AspNetCore;
using Tnf.App.Configuration;
using Tnf.Modules;
using Tnf.Zero.Application;
using Tnf.Zero.Common;

namespace Tnf.Zero.Web
{
    [DependsOn(
        typeof(AppModule),
        typeof(TnfAppAspNetCoreModule))]
    public class WebModule : TnfModule
    {
        private IHostingEnvironment _env;
        public WebModule(IHostingEnvironment env)
        {
            _env = env;
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            var configuration = Configuration
                                    .Settings
                                    .FromJsonFiles(_env.ContentRootPath, $"appsettings.{_env.EnvironmentName}.json");

            Configuration.DefaultNameOrConnectionString = configuration.GetConnectionString(AppConsts.ConnectionStringName);
        }

        public override void Initialize()
        {
            base.Initialize();

            IocManager.RegisterAssemblyByConvention<WebModule>();
        }
    }
}