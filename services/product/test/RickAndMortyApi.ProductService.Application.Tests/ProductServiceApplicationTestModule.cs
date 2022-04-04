using Volo.Abp.Modularity;

namespace RickAndMortyApi.ProductService;

[DependsOn(
    typeof(ProductServiceApplicationModule),
    typeof(ProductServiceDomainTestModule)
    )]
public class ProductServiceApplicationTestModule : AbpModule
{

}
