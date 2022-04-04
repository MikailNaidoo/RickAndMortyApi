using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(CharacterServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CharacterServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(CharacterServiceApplicationContractsModule).Assembly,
            CharacterServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CharacterServiceHttpApiClientModule>();
        });
    }
}
