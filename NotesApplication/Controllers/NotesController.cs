using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Models;
using NotesApplication.Services;
using NotesApplication.ViewModel;


namespace NotesApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly NoteService _service;
        private readonly IMapper _mapper;

        public NotesController(NoteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var notes = _service.GetAllNotes();
            var vmList = _mapper.Map<List<NoteViewModel>>(notes); // Domain -> ViewModel
            return View(vmList);
        }

        public IActionResult Create()
        {
            return View(new NoteViewModel());
        }

        [HttpPost]
        public IActionResult Create(NoteViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            // Use service which internally uses NoteFactory
            _service.AddNote(vm.Title, vm.Description, vm.Priority);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var note = _service.GetNote(id);
            if (note == null) return NotFound();

            var vm = _mapper.Map<NoteViewModel>(note);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, NoteViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid)
                return View(vm);

            var note = _mapper.Map<Note>(vm);
            _service.UpdateNote(note);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var note = _service.GetNote(id);
            if (note == null) return NotFound();

            var vm = _mapper.Map<NoteViewModel>(note);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteNote(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
