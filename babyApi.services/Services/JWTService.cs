using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.domain.Dto;
using babyApi.services.Interfaces;


namespace babyApi.services.Services
{
    public class JWTService : IJWTService
    {
        private readonly IGenericRepository<User> _userRepo;
        public JWTService(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public UserDto UserLogin(UserDto userDto)
        {
            var userLogged = _userRepo.GetBy(x => x.Name.Equals(userDto.Name)).FirstOrDefault();
            if (userLogged == null)
                return new UserDto();

            var userDtoLogged = new UserDto
            {
                Name = userLogged.Name,
                Email = userLogged.Email,
                Id = userLogged.Id
            };
            return userDtoLogged;
        }

    }
}
