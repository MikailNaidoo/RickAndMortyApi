﻿using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.IdentityService;

[DependsOn(
    typeof(AbpIdentityProDomainModule),
    typeof(AbpIdentityServerDomainModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceDomainModule : AbpModule
{
}
