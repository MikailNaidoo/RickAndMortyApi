using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RickAndMortyApi.ProductService.Products;

public interface IProductAppService : ICrudAppService<ProductDto, Guid, GetProductsInput, ProductCreateDto, ProductUpdateDto>
{

}
