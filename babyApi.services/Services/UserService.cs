using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.services.Interfaces;

namespace babyApi.services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetValideUsers(int Id)
        {
            
            return await _userRepository.GetValideUsers(Id);
        }
    }
}
