﻿using RickAndMortyApi.SaasService.Application;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
