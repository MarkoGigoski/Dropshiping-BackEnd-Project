using Dropshiping.BackEnd.Domain.UserModels;

namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public string ImageId { get; set; }
        public virtual Image ProductImage { get; set; }

        //public decimal Raiting { get; set; } 


        // Properties for relations
        public virtual Subcategory Subcategory { get; set; }
        public string SubcategoryId { get; set; }


        public virtual Region Region { get; set; }
        public string RegoinId { get; set; }



        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public virtual ICollection<Raiting> Raitings { get; set; }
    }
}

        
    
