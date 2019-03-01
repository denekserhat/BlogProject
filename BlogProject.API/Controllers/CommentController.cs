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
    public class CommentController : Controller
    {
        private readonly CommentManager commentManager;
        private readonly IMapper mapper;

        public CommentController(CommentManager _commentManager, IMapper _mapper)
        {
            commentManager = _commentManager;
            mapper = _mapper;
        }

        [HttpGet("getcomment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var note = await commentManager.GetComment(id);

            // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(note);
        }

        [HttpGet("getcomments")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await commentManager.GetComments();

            // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(categories);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertNote(CommentInsertModel commentModel)
        {
            var insertValue = mapper.Map<Comment>(commentModel);

            await commentManager.Insert(insertValue);

            return StatusCode(201);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNote(int id)
        {

            Comment comment = await commentManager.GetComment(id);
            await commentManager.Delete(comment);

            return StatusCode(201);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNote(CommentUpdateModel commentModel)
        {

            Comment comment = await commentManager.GetComment(commentModel.Id);

            await commentManager.Update(comment);

            return StatusCode(201);
        }
    }
}