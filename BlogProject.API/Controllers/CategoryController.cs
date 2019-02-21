using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
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

        [HttpGet("api/GetCategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryManager.GetCategories(id);

            var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(categoryToReturn);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}