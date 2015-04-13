﻿using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace ASX.DataAccess
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private ObjectSet<T> _objectSet;

        public SqlRepository(ObjectContext context)
        {
            _objectSet = context.CreateObjectSet<T>();
        }

        public void Add(T entity)
        {
            _objectSet.AddObject(entity);
        }

        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }
    }
}