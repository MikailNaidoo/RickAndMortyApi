using System;
using RickAndMortyApi.ProductService.EntityFrameworkCore;
using RickAndMortyApi.Shared.Hosting.Microservices.DbMigrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace RickAndMortyApi.ProductService.DbMigrations;

public class ProductServiceDatabaseMigrationChecker : PendingMigrationsCheckerBase<ProductServiceDbContext>
{
    public ProductServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            ProductServiceDbProperties.ConnectionStringName)
    {

    }
}
