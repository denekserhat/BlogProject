using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    public class LikeController : Controller
    {
        private readonly LikeManager likeManager;
        private readonly IMapper mapper;

        public LikeController(LikeManager _likeManager, IMapper _mapper)
        {
            likeManager = _likeManager;
            mapper = _mapper;
        }

        [HttpGet("getlikes")]
        public IActionResult GetLikes(int userId, int[] likedNoteIds)
        {

            var likes = likeManager.GetLikes(userId, likedNoteIds);

            // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(likes);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertNote(Like like)
        {
            //var insertValue = mapper.Map<Like>(commentModel);

            await likeManager.Insert(like);

            return StatusCode(201);
        }

    }
}