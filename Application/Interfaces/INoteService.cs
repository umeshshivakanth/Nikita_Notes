using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetAllNotes();
        NoteDto GetNoteById(int id);
        void CreateNote(NoteDto noteDto);
        void UpdateNote(NoteDto noteDto);
        void DeleteNote(int id);
    }
}
