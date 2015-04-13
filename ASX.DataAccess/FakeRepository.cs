using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ASX.DataAccess
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        private readonly HashSet<T> _set;
        private readonly IQueryable<T> _queryableSet;

        public FakeRepository() : this(Enumerable.Empty<T>())
        {
        }

        public FakeRepository(IEnumerable<T> entities)
        {
            _set = new HashSet<T>();
            foreach (var entity in entities)
            {
                _set.Add(entity);
            }
            _queryableSet = _set.AsQueryable();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _queryableSet;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _queryableSet.Where(predicate);
        }
    }
}