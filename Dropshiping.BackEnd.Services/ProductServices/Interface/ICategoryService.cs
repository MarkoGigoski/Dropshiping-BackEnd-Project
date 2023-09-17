using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Services.ProductServices.Interface
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDtoForImageObj GetById(string id);
        void Add(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
        void DeleteById(string id);
    }
}
