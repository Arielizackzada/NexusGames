using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusGames.Data;
using NexusGames.Models;

namespace NexusGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public IActionResult Index()
        {
            var games = _context.Games.Include(g => g.Category).ToList();
            return View(games);
        }

        // GET: Games/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var game = _context.Games
                .Include(g => g.Category)
                .FirstOrDefault(g => g.Id == id);

            if (game == null) return NotFound();

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Re-populate categories if validation fails
            ViewBag.Categories = _context.Categories.ToList();
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var game = _context.Games.Find(id);
            if (game == null) return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(game);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Game game)
        {
            if (id != game.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Games.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Re-populate categories if validation fails
            ViewBag.Categories = _context.Categories.ToList();
            return View(game);
        }

        // GET: Games/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var game = _context.Games
                .Include(g => g.Category)
                .FirstOrDefault(g => g.Id == id);

            if (game == null) return NotFound();

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
