using Microsoft.AspNetCore.Mvc;
using NotesApplication.Data;
using NotesApplication.Models;
using System.Diagnostics.CodeAnalysis;

namespace NotesApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;

        }
        public  IActionResult Index()
        {
            Console.WriteLine($"context is {_context == null}");
          var notes = _context.Notes.OrderByDescending(n=>n.CreatedAt).ToList();
            return View(notes);
        }
        public IActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Edit(int id )
        {
            var note = _context.Notes.Find(id);
            if ((note == null))
                return NotFound();
            return View(note);
        }


        [HttpPost]
        public IActionResult Edit(int id, Note note)
        {

            if(id!=note.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }



      
        public IActionResult Delete(int id)
        {

            var note = _context.Notes.Find(id);
            if ((note == null))
                return NotFound();
            return View(note);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {

            var note = _context.Notes.Find(id);
            if ((note != null))
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();


            }
            return RedirectToAction("Index");
        }




















    }
}
