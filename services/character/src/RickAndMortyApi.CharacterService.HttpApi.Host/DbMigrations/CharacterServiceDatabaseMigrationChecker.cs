using System;
using RickAndMortyApi.CharacterService.EntityFrameworkCore;
using RickAndMortyApi.Shared.Hosting.Microservices.DbMigrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace RickAndMortyApi.CharacterService.DbMigrations;

public class CharacterServiceDatabaseMigrationChecker : PendingMigrationsCheckerBase<CharacterServiceDbContext>
{
    public CharacterServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            CharacterServiceDbProperties.ConnectionStringName)
    {

    }
}
