using Dropshiping.BackEnd.Enums;

namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        //public string Shiping {  get; set; } // Of what type?
        public decimal Shipping { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
