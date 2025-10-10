using NotesApplication.Data;
using NotesApplication.Models;
using System;

namespace NotesApplication.Repositories
{
    public class NoteRepository :INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Note> GetAll()
        {
            return _context.Notes
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }

        public Note? GetById(int id)
        {
            return _context.Notes.Find(id);
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

    }
}
