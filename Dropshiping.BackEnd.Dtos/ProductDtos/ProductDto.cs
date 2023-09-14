using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class ProductDto : BaseEntity
    {
        public string Name {  get; set; }
        public decimal Price {  get; set; }
        public int Stock { get; set; }
        public string Description {  get; set; }

    }
}
