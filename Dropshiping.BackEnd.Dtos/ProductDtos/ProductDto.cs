﻿using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class ProductDto : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; } 
        public string SubcategoryId { get; set; }
        public string RegoinId { get; set; }
    }
}
