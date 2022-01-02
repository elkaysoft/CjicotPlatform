using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cjicot.Persistence.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetSingleOrDefault(Func<T, bool> predicate);
        T GetLastOrDefault(Func<T, bool> predicate);
        T GetFirstOrDefault(Func<T, bool> predicate);
        T GetByID(object id);
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        int Update(T entity);
        int Insert(T entity);
        int InsertRange(IEnumerable<T> entities);
        int Delete(T entity);       
        IQueryable<T> GetAndInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);        
    }
}
