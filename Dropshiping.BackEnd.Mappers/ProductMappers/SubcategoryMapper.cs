using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Mappers.ProductMappers
{
    public static class SubcategoryMapper
    {
        public static SubcategoryDto ToDtoSub(this Subcategory subcategory)
        {
            return new SubcategoryDto
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                Description = subcategory.Description,
                CategoryId = subcategory.CategoryId,
            };
        }
    }
}
