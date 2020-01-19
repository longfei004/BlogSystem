using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlogSystem.DataAccess.DataContext;

namespace BlogSystem.DataAccess.Repository
{
    public class BlogRepository<T> : IRepository<T> where T:class
    {
        private readonly BlogContext _context;
        
        private DbSet<T> _objectSet;

        public BlogRepository(BlogContext context)
        {
            _context = context;
            _objectSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if(predicate!=null) 
                return _objectSet.Where(predicate);

            return _objectSet;
        }

        public T Get(Func<T, bool> predicate)
        {
            try
            {
                return _objectSet.First(predicate);
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        public T Add(T entity)
        {
            _objectSet.AddAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T Delete(T entity)
        {
            _objectSet.Remove(entity);

            return entity;
        }

        public bool IsExists(T entity)
        {
            return _objectSet.Any(e => entity.Equals(e));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int Length()
        {
            return _objectSet.Count();
        }
    }
}