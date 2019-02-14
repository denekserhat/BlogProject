using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Repository<T> : IRepository<T>
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

        public int Insert(T entity)
        {
            dbSetObject.Add(entity);
            return blogContext.SaveChanges();
        }

        public int Remove(T entity)
        {
            dbSetObject.Remove(entity);
            return blogContext.SaveChanges();
        }

        public int Update(T entity)
        {
            return blogContext.SaveChanges();
        }
    }
}
