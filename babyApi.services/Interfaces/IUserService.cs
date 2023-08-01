using babyApi.domain;
using System.Linq.Expressions;

namespace babyApi.services.Interfaces
{
    public interface IUserService
    {

        bool Add(User model);

        bool Update(User model);
        bool Delete(User model);

        User GetById(int id);
        IEnumerable<User> GetAll();

        IEnumerable<User> GetBy(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes);

        public Task<IEnumerable<User>> GetValideUsers(int Id);
            
    }
}
