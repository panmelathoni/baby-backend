using babyApi.domain.Dto;
using System.Linq.Expressions;

namespace babyApi.data.Repositories

{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T model );
        bool Update(T model);
        bool Delete(T model);

        T GetById(int id);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
       
    }
}
