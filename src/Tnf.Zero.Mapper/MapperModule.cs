using Tnf.App.AutoMapper;
using Tnf.Modules;

namespace Tnf.Zero.Mapper
{
    [DependsOn(typeof(TnfAutoMapperModule))]
    public class MapperModule : TnfModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();

            Configuration.Modules
                .TnfAutoMapper()
                .Configurators
                .Add(config =>
                {
                    config.AddProfile(new DomainToDtoProfile());
                });
        }
    }
}
