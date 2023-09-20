using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos.CategoryDtos;

namespace Dropshiping.BackEnd.Mappers.ProductMappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDtoCat(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                

            };
        }
    }
}
