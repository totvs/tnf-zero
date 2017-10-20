using Tnf.Zero.Common;
using Tnf.App;
using Tnf.Localization;
using Tnf.Localization.Dictionaries;
using Tnf.Localization.Dictionaries.Json;
using Tnf.Modules;

namespace Tnf.Zero.Domain
{
    [DependsOn(typeof(TnfAppModule))]
    public class DomainModule : TnfModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", isDefault: true));
            Configuration.Localization.Languages.Add(new LanguageInfo("pt-BR", "Português"));

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(AppConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DomainModule).Assembly,
                        "Tnf.Zero.Solution.Domain.Localization.SourceFiles"
                    )
                )
            );

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(TnfAppConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DomainModule).Assembly,
                        "Tnf.Zero.Solution.Domain.Localization.TnfSourceFiles"
                    )
                )
            );

            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention<DomainModule>();
        }
    }
}
