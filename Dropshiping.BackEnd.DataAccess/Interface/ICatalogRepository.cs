using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Interface
{
    public interface ICatalogRepository
    {
        public void Add(Catalog entity);
    }
}
