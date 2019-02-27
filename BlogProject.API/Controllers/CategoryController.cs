using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryManager categoryManager;
        private readonly IMapper mapper;

        public CategoryController(CategoryManager _categoryManager, IMapper _mapper)
        {
            categoryManager = _categoryManager;
            mapper = _mapper;
        }

        [HttpGet("getcategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryManager.GetCategory(id);

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(category);
        }

        [HttpGet("getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryManager.GetCategories();

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(categories);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertCategory(CategoryInsertModel model)
        {
            var insertValue = mapper.Map<Category>(model);

            await categoryManager.Insert(insertValue);

            return StatusCode(201);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
 
            Category category = await categoryManager.GetCategory(id);
            await categoryManager.Delete(category);

            return StatusCode(201);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateModel categoryModel)
        {
 
            Category category = await categoryManager.GetCategory(categoryModel.Id);
            
            await categoryManager.Update(category);

            return StatusCode(201);
        }

      
    }
}