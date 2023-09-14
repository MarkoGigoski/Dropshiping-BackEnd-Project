namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CatalogId { get; set; }

        // Properties for relations
        public Catalog Catalog { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
