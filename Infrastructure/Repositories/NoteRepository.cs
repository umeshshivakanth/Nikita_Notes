using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public  class NoteRepository : INoteRepository
    {

        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.Include(n => n.Category)
                                 .OrderByDescending(n => n.CreatedAt)
                                 .ToList();
        }

        public Note GetById(int id)
        {
            return _context.Notes.Include(n => n.Category)
                                 .FirstOrDefault(n => n.Id == id);
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
