using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class SubcategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
