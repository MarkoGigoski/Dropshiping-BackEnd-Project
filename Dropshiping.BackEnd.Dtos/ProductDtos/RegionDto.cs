using Dropshiping.BackEnd.Domain;

namespace Dropshiping.BackEnd.Dtos.ProductDtos
{
    public class RegionDto : BaseEntity
    {
        public string Name {  get; set; }
        public decimal Shipping { get; set; }
    }
}
