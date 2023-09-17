using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class ImageRepository : IRepository<Image>
    {
        private DropshipingDbContext _dbContext;
        public ImageRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Image entity)
        {
            _dbContext.Images.Add(entity);  
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetAll()
        {
            throw new NotImplementedException();
        }

        public Image GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
