using RickAndMortyApi.CharacterService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.CharacterService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CharacterServiceEntityFrameworkCoreTestModule)
    )]
public class CharacterServiceDomainTestModule : AbpModule
{

}
