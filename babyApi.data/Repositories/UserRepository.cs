using babyApi.data.Context;
using babyApi.domain;
using Microsoft.EntityFrameworkCore;

namespace babyApi.data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext ctx) : base(ctx) { }

        public async Task<List<User>> GetValideUsers(int Id)
        {
            return await _ctx.Set<User>()
                
                .Where(i => i.Id == Id)
                .ToListAsync();
        }
    }
}
