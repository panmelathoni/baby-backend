using babyApi.domain;
using babyApi.domain.Dto;


namespace babyApi.services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetValideUsers(int Id);
            
    }
}
