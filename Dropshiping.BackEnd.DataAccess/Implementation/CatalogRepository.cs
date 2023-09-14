using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class CatalogRepository : ICatalogRepository
    {
        private DropshipingDbContext _dbContext;
        public CatalogRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Catalog entity)
        {
            _dbContext.Catalogs.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
