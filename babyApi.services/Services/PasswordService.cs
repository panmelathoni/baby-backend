using babyApi.services.Interfaces;
using System.Security.Cryptography;
using System.Text;


namespace babyApi.services.Services
{
    public class PasswordService : IPasswordService

        
    {
        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())

            {
                return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key);
               
            }
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

       
    }
}
