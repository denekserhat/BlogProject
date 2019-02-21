using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager
    {
        IRepository<Category> categoryRepository;
        public CategoryManager(IRepository<Category> _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<List<Category>> GetCategories(int id)
        {
            var returnValues = await categoryRepository.GetListAsync();
            return returnValues;
        }

        public void Insert(Category category)
        {
            categoryRepository.Insert(category);
        }

        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            categoryRepository.Remove(category);
        }

    }
}
