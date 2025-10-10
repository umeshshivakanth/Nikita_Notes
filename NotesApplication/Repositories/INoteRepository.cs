using NotesApplication.Models;

namespace NotesApplication.Repositories
{
    public interface INoteRepository
    {
        List<Note> GetAll();
        Note? GetById(int id);
        void Add(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
