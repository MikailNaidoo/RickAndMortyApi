using System;
using RickAndMortyApi.AdministrationService.EntityFrameworkCore;
using RickAndMortyApi.Shared.Hosting.Microservices.DbMigrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace RickAndMortyApi.AdministrationService.DbMigrations;

public class AdministrationServiceDatabaseMigrationChecker : PendingMigrationsCheckerBase<AdministrationServiceDbContext>
{
    public AdministrationServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            AdministrationServiceDbProperties.ConnectionStringName)
    {

    }
}
