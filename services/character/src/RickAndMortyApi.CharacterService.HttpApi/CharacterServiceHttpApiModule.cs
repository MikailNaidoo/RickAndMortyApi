using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using RickAndMortyApi.CharacterService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(CharacterServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CharacterServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CharacterServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CharacterServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
