﻿using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;

namespace RickAndMortyApi.AdministrationService;

[DependsOn(
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(LeptonThemeManagementApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(TextTemplateManagementApplicationContractsModule),
    typeof(AdministrationServiceDomainSharedModule)
)]
public class AdministrationServiceApplicationContractsModule : AbpModule
{
}
