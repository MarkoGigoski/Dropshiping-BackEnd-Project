namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Orderitem : BaseEntity
    {
        public int Quantity { get; set; }

        // Relation conections
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }

    }
}
