namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Subcategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        // Properties for relations
        public Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
