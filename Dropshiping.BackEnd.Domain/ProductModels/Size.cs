namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; } //Dodadena von crtez za konekcija .HasMany
    }
}
