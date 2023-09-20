using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos.CategoryDtos
{
    public class CategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
