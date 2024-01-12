using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using NotesProcessor;

namespace NotesWebMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteProcessor _noteProcessor;

        public NoteController(INoteProcessor noteProcessor)
        {
            _noteProcessor = noteProcessor;
        }

        // GET: NoteController
        public IActionResult Index()
        {
            IEnumerable<Note> notes = _noteProcessor.GetAll();
            return View(notes);
        }

        // GET: NoteController/Detail/id
        public IActionResult Detail(Guid id)
        {
            Note noteFromDb = _noteProcessor.Get(id);
            
            if (noteFromDb is null)
                return NotFound();

            return View(noteFromDb);
        }

        // GET: NoteController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note obj)
        { 
            if (ModelState.IsValid)
            {
                _noteProcessor.Create(obj);
                TempData["success"] = "Note created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: NoteController/Edit/id
        public IActionResult Edit(Guid id)
        {
            var noteFromDb = _noteProcessor.Get(id);

            if (noteFromDb is null)
                return NotFound();

            return View(noteFromDb);
        }

        // POST: NoteController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            if (ModelState.IsValid)
            {
                _noteProcessor.Update(obj);
                TempData["success"] = "Note updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: NoteController/Delete/id
        public IActionResult Delete(Guid id)
        {
            var noteFromDb = _noteProcessor.Get(id);

            if (noteFromDb is null)
                return NotFound();

            return View(noteFromDb);
        }

        // POST: NoteController/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid id)
        {
            var noteFromDb = _noteProcessor.Get(id);

            if (noteFromDb is null)
                return NotFound();

            _noteProcessor.Delete(id);
            TempData["success"] = "Note deleted successfylly";
            return RedirectToAction("Index");
        }
    }
}
