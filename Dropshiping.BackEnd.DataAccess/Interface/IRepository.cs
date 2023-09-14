namespace Dropshiping.BackEnd.DataAccess.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
