using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.UserModels;

namespace Dropshiping.BackEnd.DataAccess.Implementation
{
    public class UserRepository : IRepository<User>
    {
        private DropshipingDbContext _dbContext;
        public UserRepository(DropshipingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} is not found");
            }

            return user;
        }

        public void Add(User entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = GetById(id);

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
