﻿using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class CategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageId {  get; set; }
       
    }
}
