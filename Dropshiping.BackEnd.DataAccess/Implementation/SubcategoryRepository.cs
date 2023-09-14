using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class SubcategoryRepository : IRepository<Subcategory>
    {
        private DropshipingDbContext _dbContext;
        public SubcategoryRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Subcategory> GetAll()
        {
            return _dbContext.Subcategories.ToList();
        }

        public Subcategory GetById(string id)
        {
            var subcategory = _dbContext.Subcategories.FirstOrDefault(s => s.Id == id);
            
            if (subcategory == null)
            {
                throw new KeyNotFoundException($"Subcategory with id {id} does not exist");
            }
            return subcategory;
        }

        public void Add(Subcategory entity)
        {
            _dbContext.Subcategories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Subcategory entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var subcategory = GetById(id);

            _dbContext.Subcategories.Remove(subcategory);
            _dbContext.SaveChanges();
        }
    }
}
