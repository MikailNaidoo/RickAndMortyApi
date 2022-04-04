using AutoMapper;
using RickAndMortyApi.ProductService.Products;

namespace RickAndMortyApi.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
