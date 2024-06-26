using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data;
using MyWebApplication.Models;
using MyWebApplication.ViewModels;
using System.Security.Claims;

namespace MyWebApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationContext _context;


        public NotesController(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            return View(await _context.Notes.Where(e => e.UserId.ToString() == userId).ToListAsync());
        }


        public async Task<IActionResult> CreateUpdate(int noteId)
        {
            if (noteId != 0)
            {
                var currentNote = await _context.Notes.FirstOrDefaultAsync(e => e.Id == noteId);
                if (currentNote != null)
                {
                    return View(new NoteViewModel
                    {
                        Id = currentNote.Id,
                        Description = currentNote.Description,
                        Title = currentNote.Title,
                    });
                }
                return NotFound();
            }
            else
            {
                return View(new NoteViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdate(NoteViewModel noteViewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Note note = new Note 
                {
                    Id = noteViewModel.Id,
                    Description = noteViewModel.Description,
                    Title = noteViewModel.Title,
                    UserId = new Guid(userId)
                };

                if (note.Id == 0)
                {
                    _context.Notes.Add(note);
                }
                else
                {
                    _context.Notes.Update(note);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(noteViewModel);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int noteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            var currentNote = await _context.Notes.FirstOrDefaultAsync(e => e.Id == noteId && e.UserId.ToString() == userId);
            if (currentNote != null)
            {
                _context.Notes.Remove(currentNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
