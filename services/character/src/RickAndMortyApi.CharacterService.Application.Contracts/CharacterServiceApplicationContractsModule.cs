using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(CharacterServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CharacterServiceApplicationContractsModule : AbpModule
{

}
