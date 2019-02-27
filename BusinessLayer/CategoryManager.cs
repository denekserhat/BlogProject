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

         public async Task<List<Category>> GetCategories()
        {
            var returnValues = await categoryRepository.GetListAsync();
            return returnValues;
        }
        public async Task<Category> GetCategory(int id)
        {
            var returnValue = await categoryRepository.GetAsync(x => x.Id == id);
            return returnValue;
        }

        public async Task<int> Insert(Category category)
        {
            return await categoryRepository.Insert(category);
        }

        public async Task<int> Update(Category category)
        {
            return await categoryRepository.Update(category);
        }

        public async Task<int> Delete(Category category)
        {
            return await categoryRepository.Remove(category);
        }

    }
}
