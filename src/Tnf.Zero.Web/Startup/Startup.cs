using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Tnf.Configuration;
using Tnf.Zero.Common;
using Tnf.Zero.Domain;
using Tnf.Zero.EntityFrameworkCore;
using Tnf.Zero.Mapper;

namespace Tnf.Zero.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services
                .AddZeroDomain()
                .AddZeroMapper()
                .AddZeroEntityFrameworkCore()
                .AddTnfAspNetCore();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseTnfAspNetCore(options =>
            {
                options.ConfigureZeroLocalization();

                // Set connection string
                var configuration = options.Settings.FromJsonFiles(env.ContentRootPath, $"appsettings.json");

                options.DefaultPageSize(configuration);

                options.DefaultNameOrConnectionString = configuration.GetConnectionString(AppConsts.ConnectionStringName);
            });

            // Tnf Unit of Work
            app.UseTnfUnitOfWork();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Add CORS middleware before MVC
            app.UseCors("AllowAll");

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi(); //URL: /swagger/ui
        }
    }
}
