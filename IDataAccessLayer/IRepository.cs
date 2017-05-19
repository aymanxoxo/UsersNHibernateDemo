using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class 
    {
        T Find(object id);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
