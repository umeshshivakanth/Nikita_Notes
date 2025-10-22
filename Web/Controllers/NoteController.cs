using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BasicNotesApp.Web.ViewModel;

namespace BasicNotesApp.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var notesDto = _noteService.GetAllNotes();
            var notesVm = _mapper.Map<IEnumerable<NoteViewModel>>(notesDto);
            return View(notesVm);
        }

        public IActionResult Create()
        {
            PopulateCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(NoteViewModel noteVm)
        {
            if (ModelState.IsValid)
            {
                var noteDto = _mapper.Map<NoteDto>(noteVm);
                _noteService.CreateNote(noteDto);

                return RedirectToAction(nameof(Index));
            }
            PopulateCategories();
            return View(noteVm);
        }

        public IActionResult Edit(int id)
        {
            var noteDto = _noteService.GetNoteById(id);
            if (noteDto == null) return NotFound();

            var noteVm = _mapper.Map<NoteViewModel>(noteDto);
            PopulateCategories();
            return View(noteVm);
        }

        [HttpPost]
        public IActionResult Edit(NoteViewModel noteVm)
        {
            if (ModelState.IsValid)
            {
                var noteDto = _mapper.Map<NoteDto>(noteVm);
                _noteService.UpdateNote(noteDto);
                return RedirectToAction(nameof(Index));
            }
            PopulateCategories();
            return View(noteVm);
        }

  
        public IActionResult Delete(int id)
        {
            var noteDto = _noteService.GetNoteById(id);
            if (noteDto == null) return NotFound();

            var noteVm = _mapper.Map<NoteViewModel>(noteDto);
            return View(noteVm); 
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _noteService.DeleteNote(id);
            return RedirectToAction(nameof(Index));
        }


        private void PopulateCategories()
        {
           
            ViewBag.Categories = new SelectList(new[]
            {
                new { Id = 1, Name = "Work" },
                new { Id = 2, Name = "Personal" },
                new { Id = 3, Name = "Misc" }
            }, "Id", "Name");
        }
    }
}
