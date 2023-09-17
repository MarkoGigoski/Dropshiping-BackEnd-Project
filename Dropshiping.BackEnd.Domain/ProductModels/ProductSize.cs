namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class ProductSize : BaseEntity
    {
        public int Stock {  get; set; }

        // Relation conection
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public Size Size { get; set; }
        public string SizeId { get; set; }  

        public virtual ICollection<Orderitem> Orderitems { get; set; } //Dodadena von crtez za konekcija .HasMany

    }
}
