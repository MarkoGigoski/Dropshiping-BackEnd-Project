namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        // Relations
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public Product Product { get; set; }
    }
}
