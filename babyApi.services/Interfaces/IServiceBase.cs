using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace babyApi.services.Interfaces
{
    public interface IServiceBase <TEntity> where TEntity : class
    {
        bool Add(TEntity model);
        bool Update(TEntity model);
        bool Delete(TEntity model);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

    }
}
