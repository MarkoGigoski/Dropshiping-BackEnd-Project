using Dropshiping.BackEnd.Domain.UserModels;

namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }

        // Properties for relations
        public string UserId {  get; set; }
        public string SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public User User { get; set; }
    }
}
