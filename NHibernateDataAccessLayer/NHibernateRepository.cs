using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer;
using NHibernate;
using NHibernate.Criterion;

namespace NHibernateDataAccessLayer
{
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public T Find(object id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            if (filter != null)
                return _session.QueryOver<T>().Fetch(x=>x).Lazy.Where(filter).List().ToList().AsQueryable();
            return _session.CreateCriteria<T>().List<T>().ToList().AsQueryable();
        }

        public void Update(T entity)
        {
            _session.Merge(entity);
        }
    }
}
