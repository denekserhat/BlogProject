using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer;
using Entities;
using Entities.Dtos;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{

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

          [HttpGet("getnotesbycategory/{id}")]
        public IActionResult GetNoteByCategory(int id)
        {
            var notes = noteManager.GetNotesByCategory(id);

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(notes);
        }

        [HttpGet("getnotes")]
        public async Task<IActionResult> GetNotes([FromQuery]NoteParams noteParams)
        {
           var notes = await noteManager.GetNotes(noteParams);

            Response.AddPagination(notes.CurrentPage, notes.PageSize, notes.TotalCount, notes.TotalPages);

           // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(notes);
        }

        [HttpGet("getnote/{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var categories = await noteManager.GetNote(id);

            // var categoryToReturn = mapper.Map<UserDetailModel>(category);

            return Ok(categories);
        }

        [HttpGet("getpopularnotes")]
        public IActionResult GetPopularNotes()
        {
            var categories = noteManager.GetPopsularNotes();

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