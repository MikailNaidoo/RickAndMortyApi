using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.IdentityService;

[DependsOn(
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpIdentityServerApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceApplicationContractsModule : AbpModule
{
}
