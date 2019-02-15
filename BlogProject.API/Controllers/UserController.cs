using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
<<<<<<< HEAD
    public class UserController : Controller
    {
        UserManager userManager;
        public UserController(UserManager _userManager)
        {
            userManager = _userManager;
=======
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager userManager;

        public UserController(UserManager manager)
        {
            userManager = manager;
>>>>>>> master
        }

        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
<<<<<<< HEAD
            var returnValue = await userManager.GetUser(id);

            return Ok(returnValue);
=======
            var user = await userManager.Get(id);
            return Ok(user);
>>>>>>> master
        }
    }
}