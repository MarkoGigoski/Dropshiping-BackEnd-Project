using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private DropshipingDbContext _dbContext;
        public CategoryRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(string id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} does not exist");
            }
            return category;
        }
        public Category GetByIdNest(string id)
        {
            var category = _dbContext.Categories.Include(x => x.Subcategories).ThenInclude(x => x.Products.Select(p => new { p.ProductSizes, p.Region, p.Raitings })).FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} does not exist");
            }
            return category;
        }

        public void Add(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var category = GetById(id);

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

    }
}
