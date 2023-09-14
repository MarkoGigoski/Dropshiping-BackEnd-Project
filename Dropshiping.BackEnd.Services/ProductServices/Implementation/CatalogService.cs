using Dropshiping.BackEnd.DataAccess.Implementation;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class CatalogService : ICatalogService
    {
        private CatalogRepository _catalogRepository;
        public CatalogService(CatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public void Add(CatalogDto catalogDto)
        {
            if (catalogDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }

            var catalog = new Catalog
            {
                Name = catalogDto.Name,
            };

            _catalogRepository.Add(catalog);    
        }
    }
}
