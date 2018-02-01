using Tnf.EntityFrameworkCore.TestBase;
using Microsoft.Extensions.DependencyInjection;
using Tnf.Zero.Mapper;
using System;
using Tnf.Zero.EntityFrameworkCore;

namespace Tnf.Zero.Domain.Tests.App
{
    public class DomainTestBase : TnfEfCoreIntegratedTestBase
    {
        protected override void PreInitialize(IServiceCollection services)
        {
            services
                .AddZeroDomain()
                .AddZeroMapper();

            services
                .AddTnfEfCoreSqliteInMemory()
                .RegisterDbContextToSqliteInMemory<ZeroContext>();
        }

        protected override void PostInitialize(IServiceProvider provider)
        {
            provider.ConfigureTnf().ConfigureZeroLocalization();
        }
    }
}
