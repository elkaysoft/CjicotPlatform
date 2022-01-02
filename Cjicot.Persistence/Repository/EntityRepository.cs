using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private CjcotContext _context;
        private DbSet<T> dbSet;


        public EntityRepository(CjcotContext cjcotContext)
        {
            _context = cjcotContext;
            dbSet = _context.Set<T>();
        }

        public int Delete(T entity)
        {
            dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToListAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public IQueryable<T> GetAndInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public T GetFirstOrDefault(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public T GetLastOrDefault(Func<T, bool> predicate)
        {
            return dbSet.LastOrDefault(predicate);  
        }

        public T GetSingleOrDefault(Func<T, bool> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public int Insert(T entity)
        {
            dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int InsertRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            dbSet.Update(entity);
            return _context.SaveChanges();
        }
    }
}
