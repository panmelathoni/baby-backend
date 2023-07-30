using babyApi.data.Context;
using babyApi.domain;

namespace babyApi.data.Repositories
{
    public class BabyProfileRepository : GenericRepository<BabyProfile>, IBabyProfileRepository
    {
        public BabyProfileRepository(DataContext ctx) : base(ctx)
        {
        }

    }
}
