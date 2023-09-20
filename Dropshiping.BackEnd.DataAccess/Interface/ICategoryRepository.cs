using Dropshiping.BackEnd.Domain.ProductModels;

namespace Dropshiping.BackEnd.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(string id);
        Category GetByIdNest(string id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(string id);
    }
}
