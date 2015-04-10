using System;
using System.Linq;
using System.Linq.Expressions;

namespace ASX.BusinessLayer
{
    public interface IRepository<T> where T : class
    {
        void Add(T newEntity);
        void Remove(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();
    }
}