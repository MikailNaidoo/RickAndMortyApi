using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.Shared.Hosting.AspNetCore;

[DependsOn(
    typeof(RickAndMortyApiSharedHostingModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class RickAndMortyApiSharedHostingAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
