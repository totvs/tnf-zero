using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Threading.Tasks;
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
            services
                .AddCorsAll("AllowAll")
                .AddZeroDomain()
                .AddZeroMapper()
                .AddZeroEntityFrameworkCore()
                .AddTnfAspNetCore();

            services
                .AddResponseCompression()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Tnf Zero API", Version = "v1" });
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Tnf.Zero.Web.xml"));
                });

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowAll");

            app.UseTnfAspNetCore(options =>
            {
                options.UseZeroLocalization();

                // Set connection string
                var configuration = options.Settings.FromJsonFiles(env.ContentRootPath, $"appsettings.json");

                options.DefaultPageSize(configuration);

                options.DefaultNameOrConnectionString = configuration.GetConnectionString(AppConsts.ConnectionStringName);
            });

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tnf Zero API v1");
            });

            app.UseMvcWithDefaultRoute();
            app.UseResponseCompression();

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }
    }
}
