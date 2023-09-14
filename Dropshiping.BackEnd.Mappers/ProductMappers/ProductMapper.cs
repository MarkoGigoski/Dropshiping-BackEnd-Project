using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos;
using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Mappers.ProductMappers
{
    public static class ProductMapper
    {
        //Product to ProductDto
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
            };
        }
    }
}
