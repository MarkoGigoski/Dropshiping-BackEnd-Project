﻿using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class CategoryDtoForImageObj : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName {get; set;}
    }
}
