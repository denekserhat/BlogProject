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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager userManager;
        private readonly IMapper mapper;
        public UserController(UserManager _userManager, IMapper _mapper)
        {
            userManager = _userManager;
            mapper = _mapper;
        }

        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userManager.GetUser(id);

            var userToReturn = mapper.Map<UserDetailModel>(user);

            return Ok(userToReturn);
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var returnValue = await userManager.GetUsers();
            
            return Ok(returnValue);
        }
    }
}