using babyApi.domain.Dto;


namespace babyApi.services.Interfaces
{
    public interface IJWTService
    {
       
        public UserDto UserLogin(UserDto userDto);

        public string CreateToken(string username);

       
    }
}
