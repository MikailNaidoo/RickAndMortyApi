using System;
using RickAndMortyApi.SaasService.EntityFramework;
using RickAndMortyApi.Shared.Hosting.Microservices.DbMigrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace RickAndMortyApi.SaasService.DbMigrations;

public class SaasServiceDatabaseMigrationChecker : PendingMigrationsCheckerBase<SaasServiceDbContext>
{
    public SaasServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            SaasServiceDbProperties.ConnectionStringName)
    {

    }
}
