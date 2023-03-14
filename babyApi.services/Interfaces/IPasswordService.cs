using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.services.Interfaces
{
    public interface IPasswordService
    {
        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);

       public bool VerifyPassword (string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
