using babyApi.domain;
using System.Linq.Expressions;


namespace babyApi.services.Interfaces
{
    public interface IBabyProfileService 
    {
        bool Add(BabyProfile model);
        
        bool Update(BabyProfile model);
        bool Delete(BabyProfile model);

        BabyProfile GetById(int id);
        IEnumerable<BabyProfile> GetAll();

        IEnumerable<BabyProfile> GetBy(Expression<Func<BabyProfile, bool>> predicate, params Expression<Func<BabyProfile, object>>[] includes);

    }
}
