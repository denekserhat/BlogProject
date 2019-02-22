using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //ilerde lazım olursa diye U ekledtım
    public interface IRepository<T> 
        where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<List<T>> GetListAsync();

        Task<int> Insert(T entity);

        Task<int> Remove(T entity);

        Task<int> Update(T entity);
    }
}
