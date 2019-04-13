using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using System.Linq;
using Helper;
namespace BusinessLayer
{
    public class NoteManager
    {
        IRepository<Note> noteRepository;
        public NoteManager(IRepository<Note> _noteRepository)
        {
            noteRepository = _noteRepository;
        }

         public async Task<PagedList<Note>> GetNotes(NoteParams noteParams)
        {
            var returnValues = await noteRepository.GetListAsyncForNote(noteParams);
            //it should be queryable due to pagedlist 
            // var notes = returnValues.Result.AsQueryable();
            //return await PagedList<Note>.CreateAsync(notes, noteParams.PageNumber, noteParams.PageSize);
            return returnValues;
        }
        public List<Note> GetPopsularNotes()
        {
            var returnValues = noteRepository.FindList(null, "Comments", "Likes", "Photos").Result;
            return returnValues;
        }

        public List<Note> GetNotesByCategory(int id)
        {
            var returnValues = noteRepository.FindList(x => x.CategoryId == id);
            return returnValues;
        }


        public async Task<Note> GetNote(int id)
        {
            var returnValue = await noteRepository.GetAsync(x => x.Id == id);
            return returnValue;
        }

        public async Task<int> Insert(Note note)
        {
            return await noteRepository.Insert(note);
        }

        public async Task<int> Update(Note note)
        {
            return await noteRepository.Update(note);
        }

        public async Task<int> Delete(Note note)
        {
            return await noteRepository.Remove(note);
        }
    }
}
