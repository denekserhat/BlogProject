using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T>
        where T : class
 
    {
        private BlogContext blogContext;
        private DbSet<T> dbSetObject;

        public Repository(BlogContext context)
        {
            blogContext = context;
            dbSetObject = blogContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSetObject.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await dbSetObject.ToListAsync();
        }

        public async Task<List<T>> IncludeAsync(Expression<Func<T, object>> includeFilter)
        {
            return await dbSetObject.Include(includeFilter).ToListAsync();
        }
        //for join tables
        public List<T> FindListAsync(Expression<Func<T, bool>> filter)
        {
            return dbSetObject.Where(filter).ToList();
        }

        public async Task<int> Insert(T entity)
        {
             dbSetObject.Add(entity);
             return await blogContext.SaveChangesAsync();
        }

        public async Task<int> Remove(T entity)
        {
            dbSetObject.Remove(entity);
            return await blogContext.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            return await blogContext.SaveChangesAsync();
        }

     
    }
}
