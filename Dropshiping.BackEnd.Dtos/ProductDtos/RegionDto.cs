using Dropshiping.BackEnd.Domain;
using Dropshiping.BackEnd.Enums;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class RegionDto : BaseEntity
    {
        public string Name {  get; set; }
        public decimal Shipping { get; set; }
    }
}
