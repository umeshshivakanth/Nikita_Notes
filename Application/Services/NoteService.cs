using Application.DTO;
using Application.Factories;
using Application.Interfaces;
using AutoMapper;


namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return _mapper.Map<IEnumerable<NoteDto>>(notes);
        }

        public NoteDto GetNoteById(int id)
        {
            var note = _noteRepository.GetById(id);
            return _mapper.Map<NoteDto>(note);
        }

        public void CreateNote(NoteDto noteDto)
        {
            // Use factory to create the Note entity
            var note = NoteFactory.Create(
                title: noteDto.Title,
                content: noteDto.Content,
                categoryId: noteDto.CategoryId,
                priority: noteDto.Priority
            );

            _noteRepository.Add(note);
        }

        public void UpdateNote(NoteDto noteDto)
        {
            var note = _noteRepository.GetById(noteDto.Id);
            if (note == null) return;

            note.Title = noteDto.Title;
            note.Content = noteDto.Content;
            note.Priority = noteDto.Priority;
            note.CategoryId = noteDto.CategoryId;

            _noteRepository.Update(note);
        }

        public void DeleteNote(int id)
        {
            _noteRepository.Delete(id);
        }
    }
}
