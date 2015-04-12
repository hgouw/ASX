using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace ASX.BusinessLayer
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private ObjectSet<T> _objectSet;

        public SqlRepository(ObjectContext context)
        {
            _objectSet = context.CreateObjectSet<T>();
        }

        public void Add(T newEntity)
        {
            _objectSet.AddObject(newEntity);
        }

        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }
    }
}