using Dropshiping.BackEnd.Dtos.ProductDtos;

namespace Dropshiping.BackEnd.Services.ProductServices.Interface
{
    public interface ICatalogService
    {
        void Add(CatalogDto catalogDto);
    }
}
