using Volo.Abp.Modularity;
using Volo.Saas;

namespace RickAndMortyApi.SaasService;

[DependsOn(
    typeof(SaasServiceDomainSharedModule),
    typeof(SaasDomainModule)
)]
public class SaasServiceDomainModule : AbpModule
{
}
