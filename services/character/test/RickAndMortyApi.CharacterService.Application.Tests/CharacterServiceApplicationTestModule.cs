using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

[DependsOn(
    typeof(CharacterServiceApplicationModule),
    typeof(CharacterServiceDomainTestModule)
    )]
public class CharacterServiceApplicationTestModule : AbpModule
{

}
