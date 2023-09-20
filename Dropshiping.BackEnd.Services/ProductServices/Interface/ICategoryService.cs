using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Dtos.ProductDtos.CategoryDtos;

namespace Dropshiping.BackEnd.Services.ProductServices.Interface
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(string id);
        List<ProductDto> GetByIdNested(string id);
        void Add(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
        void DeleteById(string id);
    }
}
