using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class ProductRepository : IRepository<Product>
    {
        private DropshipingDbContext _dbContext;
        public ProductRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(string id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} does not exist");
            }
            return product;
        }

        public void Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Product entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = GetById(id);

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
