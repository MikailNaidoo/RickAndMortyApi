using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RickAndMortyApi.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
public class ProductServiceDomainModule : AbpModule
{

}
