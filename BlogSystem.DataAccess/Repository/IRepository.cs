using System;
using System.Collections.Generic;

namespace BlogSystem.DataAccess.Repository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        bool IsExists(T entity);
        void SaveChanges();
    }
}