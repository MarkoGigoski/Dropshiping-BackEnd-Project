using Dropshiping.BackEnd.DataAccess.Implementation;
using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Mappers.ProductMappers;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class RegionService : IRegionService
    {
        private IRepository<Region> _regionRepository;
        public RegionService(IRepository<Region> regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public List<RegionDto> GetAll()
        {
            var regions = _regionRepository.GetAll();
            return regions.Select(x => x.ToDtoRegion()).ToList();
        }

        public RegionDto GetById(string id)
        {
            var region = _regionRepository.GetById(id);

            if (region == null)
            {
                throw new KeyNotFoundException($"Region with id {id} is not found");
            }

            return region.ToDtoRegion();
        }

        public void Add(RegionDto regionDto)
        {
            if (regionDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }

            var region = new Region
            {
                Name = regionDto.Name,
                Shipping = regionDto.Shipping,
            };

            _regionRepository.Add(region);
        }

        public void Update(RegionDto regionDto)
        {
            var region = _regionRepository.GetById(regionDto.Id);

            region.Id = regionDto.Id;
            region.Name = regionDto.Name;
            region.Shipping = regionDto.Shipping;

            if (regionDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if ((int)regionDto.Shipping > 3 || (int)regionDto.Shipping < 1)
            {
                throw new InvalidOperationException("Shipping must be set");
            }

            _regionRepository.Update(region);   
        }

        public void DeleteById(string id)
        {
            var region = GetById(id);

            if (region.Id == null)
            {
                throw new KeyNotFoundException($"Region with id {id} was not found.");
            }
            if (id == "")
            {
                throw new ArgumentException("You must enter id");
            }

            _regionRepository.Delete(region.Id);
        }
    }
}
