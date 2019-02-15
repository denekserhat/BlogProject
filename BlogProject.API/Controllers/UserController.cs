using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserManager userManager;
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
    }
}