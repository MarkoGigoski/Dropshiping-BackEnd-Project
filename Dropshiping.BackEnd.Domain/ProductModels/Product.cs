namespace Dropshiping.BackEnd.Domain.ProductModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }

        // Its calculated from Raiting Table interaction // when ICollection<Raiting> Raitings its populated
        public decimal Raiting
        {
            get
            {
                // Handle the case where there are no ratings to avoid division by zero.
                if (Raitings == null || Raitings.Count == 0)
                {
                    return 0;
                }
                // Calculate the average rating
                decimal sum = Raitings.Sum(r => (int)r.Rate); //'Rate' is the property representing the rating

                return sum / Raitings.Count;
            }
        }


        // Properties for relations
        public virtual Subcategory Subcategory { get; set; }
        public string SubcategoryId { get; set; }


        public virtual Region Region { get; set; }
        public string RegoinId { get; set; }


        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public virtual ICollection<Raiting> Raitings { get; set; }
    }
}

        
    
