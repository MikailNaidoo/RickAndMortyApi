using RickAndMortyApi.AdministrationService;
using RickAndMortyApi.AdministrationService.EntityFrameworkCore;
using RickAndMortyApi.CharacterService;
using RickAndMortyApi.CharacterService.EntityFrameworkCore;
using RickAndMortyApi.IdentityService;
using RickAndMortyApi.IdentityService.EntityFramework;
using RickAndMortyApi.ProductService;
using RickAndMortyApi.ProductService.EntityFrameworkCore;
using RickAndMortyApi.SaasService;
using RickAndMortyApi.SaasService.EntityFramework;
using RickAndMortyApi.Shared.Hosting;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.DbMigrator;

[DependsOn(
    typeof(RickAndMortyApiSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule),
    typeof(CharacterServiceApplicationContractsModule),
    typeof(CharacterServiceEntityFrameworkCoreModule)

)]
public class RickAndMortyApiDbMigratorModule : AbpModule
{

}
