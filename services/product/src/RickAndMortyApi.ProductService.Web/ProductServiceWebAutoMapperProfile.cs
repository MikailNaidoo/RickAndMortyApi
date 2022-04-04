using AutoMapper;
using RickAndMortyApi.ProductService.Products;

namespace RickAndMortyApi.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>();
    }
}
