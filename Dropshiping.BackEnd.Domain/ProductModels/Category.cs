namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Properties for relations
        public string ImageId { get; set; }
        public virtual Image CategoryImage { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
