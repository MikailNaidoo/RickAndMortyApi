using RickAndMortyApi.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RickAndMortyApi.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
