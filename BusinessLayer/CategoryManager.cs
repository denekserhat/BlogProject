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

        public async Task<Category> InsertCat()
        {
            var returnValues = await categoryRepository.Insert();
                return returnValues;
        }

    }
}
