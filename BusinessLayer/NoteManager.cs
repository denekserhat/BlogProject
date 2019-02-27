using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLayer
{
    public class NoteManager
    {
        IRepository<Note> noteRepository;
        public NoteManager(IRepository<Note> _noteRepository)
        {
            noteRepository = _noteRepository;
        }

         public async Task<List<Note>> GetNotes()
        {
            var returnValues = await noteRepository.GetListAsync();
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
