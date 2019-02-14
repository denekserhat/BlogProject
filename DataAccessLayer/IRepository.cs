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

        int Insert(T entity);

        int Remove(T entity);

        int Update(T entity);
    }
}
