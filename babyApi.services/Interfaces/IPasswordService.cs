
using babyApi.domain.Dto;

namespace babyApi.services.Interfaces
{
    public interface IPasswordService
    {
        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);

       public bool VerifyPassword (string password, byte[] passwordHash, byte[] passwordSalt);

    }
}
