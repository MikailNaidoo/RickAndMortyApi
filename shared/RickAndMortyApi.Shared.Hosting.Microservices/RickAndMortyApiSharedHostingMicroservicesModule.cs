using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using RickAndMortyApi.AdministrationService.EntityFrameworkCore;
using RickAndMortyApi.SaasService.EntityFramework;
using RickAndMortyApi.Shared.Hosting.AspNetCore;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace RickAndMortyApi.Shared.Hosting.Microservices;

[DependsOn(
    typeof(RickAndMortyApiSharedHostingAspNetCoreModule),
    typeof(AbpBackgroundJobsRabbitMqModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule)
)]
public class RickAndMortyApiSharedHostingMicroservicesModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "RickAndMortyApi:";
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("RickAndMortyApi");
        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "RickAndMortyApi-Protection-Keys");
    }
}
