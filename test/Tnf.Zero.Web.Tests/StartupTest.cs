using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Tnf.Zero.Domain;
using Tnf.Zero.EntityFrameworkCore;
using Tnf.Zero.Mapper;

namespace Tnf.Zero.Web.Tests.App
{
    public class StartupTest
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddTnfAspNetCoreSetupTest();

            services
                .AddZeroMapper()
                .AddZeroDomain();

            services
                .AddTnfEfCoreSqliteInMemory()
                .RegisterDbContextToSqliteInMemory<ZeroContext>();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseTnfAspNetCoreSetupTest(options =>
            {
                // Configure localization
                options.ConfigureZeroLocalization();
            });

            app.UseTnfUnitOfWork();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
