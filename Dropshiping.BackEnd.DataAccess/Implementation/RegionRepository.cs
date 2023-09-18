using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class RegionRepository : IRepository<Region>
    {
        private DropshipingDbContext _dbContext;
        public RegionRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Region> GetAll()
        {
            return _dbContext.Regions.ToList();

        }

        public Region GetById(string id)
        {
            var region = _dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
            {
                throw new KeyNotFoundException($"Region id {id} does not exist");
            }
          
            return region;
        }

        public void Add(Region entity)
        {
            _dbContext.Regions.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Region entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var region = GetById(id);
            if (region == null)
            {
                throw new KeyNotFoundException($"Region id {id} does not exist");
            }
            _dbContext.Regions.Remove(region);  
            _dbContext.SaveChanges();
        }
    }
}
