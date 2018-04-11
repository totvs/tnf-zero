using Tnf.Zero.Common;
using Tnf.Localization;
using Tnf.Localization.Dictionaries;
using Tnf.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tnf.Zero.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddZeroDomain(this IServiceCollection services)
        {
            // Adicona as convenções default de injeção de dependencia do Tnf
            services.AddTnfDefaultConventionalRegistrations();

            services.AddTnfDomain();

            return services;
        }

        public static ITnfConfiguration UseZeroLocalization(this ITnfConfiguration configuration)
        {
            configuration.Localization.Languages.Add(new LanguageInfo("en", "English"));
            configuration.Localization.Languages.Add(new LanguageInfo("pt-BR", "Português", isDefault: true));

            // Set the localization file for the solution errors
            configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(AppConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AppConsts).Assembly,
                        "Tnf.Zero.Domain.Localization.SourceFiles"
                    )
                )
            );

            // Set the localization file for the Tnf errors
            configuration.Localization.ReplaceTnfLocalizationSource(
                new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DomainServiceCollectionExtensions).Assembly,
                        "Tnf.Zero.Domain.Localization.TnfSourceFiles"
                    )
            );

            return configuration;
        }
    }
}
