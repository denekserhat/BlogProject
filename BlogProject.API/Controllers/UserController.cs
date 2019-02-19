using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager userManager;
        public UserController(UserManager _userManager)
        {
            userManager = _userManager;
        }

        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var returnValue = await userManager.GetUser(id);
            return Ok(returnValue);
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var returnValue = await userManager.GetUsers();
            
            return Ok(returnValue);
        }
    }
}