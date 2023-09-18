using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Mappers.ProductMappers
{
    public static class RegionMapper
    {
        public static RegionDto ToDtoRegion(this Region region)
        {
            return new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Shipping = region.Shipping,
            };
        }
    }
}
