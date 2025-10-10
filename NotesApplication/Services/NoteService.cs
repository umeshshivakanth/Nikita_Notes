using NotesApplication.Factories;
using NotesApplication.Models;
using NotesApplication.Repositories;

namespace NotesApplication.Services
{
    public class NoteService
    {


        private readonly INoteRepository _repo;

        public NoteService(INoteRepository repo)
        {
            _repo = repo;
        }

        public List<Note> GetAllNotes() => _repo.GetAll();
        public Note? GetNote(int id) => _repo.GetById(id);

        public void AddNote(string title, string description, PriorityLevel? priority = null)
        {
            var note = NoteFactory.Create(title, description, priority);
            _repo.Add(note);
        }

        public void UpdateNote(Note note) => _repo.Update(note);
        public void DeleteNote(int id) => _repo.Delete(id);
    }
}
