namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Orderitem : BaseEntity
    {
        public int Quantity { get; set; }

        // Relation conections
        public virtual Order Order { get; set; }
        public string OrderId { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public string ProductSizeId {  get; set; }

    }
}
