using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        //for join tables
        public async Task<List<T>> FindList(Expression<Func<T, bool>> filter)
        {
            return await dbSetObject.Include(filter).ToListAsync();
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
