using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CharacterServiceDomainSharedModule)
)]
public class CharacterServiceDomainModule : AbpModule
{
}
