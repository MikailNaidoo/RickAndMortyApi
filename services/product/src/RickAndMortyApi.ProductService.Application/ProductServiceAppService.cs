using RickAndMortyApi.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace RickAndMortyApi.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
