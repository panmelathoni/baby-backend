using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.services.Interfaces;
using System.Linq.Expressions;

namespace babyApi.services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Add(User model)
        {
            return _userRepository.Add(model);
        }

        public bool Delete(User model)
        {
            return (_userRepository.Delete(model)); 
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetBy(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includes)
        {
            return _userRepository.GetBy(predicate, includes);
        }

        public User GetById(int id)
        {
           return _userRepository.GetById(id);
        }

        public async Task<IEnumerable<User>> GetValideUsers(int Id)
        {
            
            return await _userRepository.GetValideUsers(Id);
        }

        public bool Update(User model)
        {
            return _userRepository.Update(model);
        }
    }
}
