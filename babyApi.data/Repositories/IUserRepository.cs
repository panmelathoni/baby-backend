using babyApi.domain;
using babyApi.domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.data.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<List<User>> GetValideUsers(int Id);
    }
}
