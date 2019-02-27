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
    public class NoteController : Controller
    {
        private readonly NoteManager noteManager;
        private readonly IMapper mapper;

        public NoteController(NoteManager _noteManager, IMapper _mapper)
        {
            noteManager = _noteManager;
            mapper = _mapper;
        }

          [HttpGet("getnote/{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var note = await noteManager.GetNote(id);

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(note);
        }

        [HttpGet("getnotes")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await noteManager.GetNotes();

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(categories);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertNote(NoteInsertModel noteModel)
        {
            var insertValue = mapper.Map<Note>(noteModel);

            await noteManager.Insert(insertValue);

            return StatusCode(201);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNote(int id)
        {
 
            Note note = await noteManager.GetNote(id);
            await noteManager.Delete(note);

            return StatusCode(201);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNote(NoteUpdateModel noteModel)
        {
 
            Note note = await noteManager.GetNote(noteModel.Id);
            
            await noteManager.Update(note);

            return StatusCode(201);
        }
    }
}