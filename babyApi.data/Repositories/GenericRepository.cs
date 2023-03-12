using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace babyApi.data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private DataContext _ctx;
        DbSet<T> _entity = null; 

        public GenericRepository(DataContext ctx)
        {
            _ctx = ctx;
            _entity = _ctx.Set<T>();
        }
        bool IGenericRepository<T>.Add(T model)
        {
            {
                try
                {
                    _entity.Add(model);
                    _ctx.SaveChanges();
                    return true;
                }

                catch
                {
                    return false;
                }
            }
        }

        bool IGenericRepository<T>.Delete(T model)
        {
            try
            {
                _entity.Remove(model );
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
            return _entity.ToList();
        }

        T IGenericRepository<T>.GetById(int id)
        {
            return _entity.Find(id);
        }

        bool IGenericRepository<T>.Update(T model)
        {
            try
            {
                _entity.Update(model);
                _ctx.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _ctx.Set<T>().AsQueryable().AsNoTracking();

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(predicate).ToList();
        }

    }
}
