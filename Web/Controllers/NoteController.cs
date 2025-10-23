using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            return View(noteVm);
        }

        [HttpPost]
        public IActionResult EditAjax([FromForm] NoteViewModel note)
        {
            if (note == null) return BadRequest();

            var noteDto = _mapper.Map<NoteDto>(note);
            _noteService.UpdateNote(noteDto);

            var updated = new
            {
                Title = note.Title,
                Content = note.Content,
                Priority = note.Priority.ToString() 
            };

            return Json(updated);
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
    }
}
