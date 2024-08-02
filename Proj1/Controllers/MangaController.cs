using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj1.Data;
using Proj1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proj1.Controllers
{
    public class MangaController : Controller
    {
        private readonly Proj1Context _context;

        public MangaController(Proj1Context context)
        {
            _context = context;
        }

        // GET: Mangas
        public async Task<IActionResult> Index(string mangaGenre, string searchString)
        {
            if (_context.Manga == null)
            {
                return Problem("Entity set 'Proj1Context' is null");
            }

            IQueryable<string> genreQuery = from m in _context.Manga
                                            orderby m.Genre
                                            select m.Genre;

            var genres = new List<string>();

            foreach (var g in genreQuery)
            {
                genres.AddRange(g.Split(", "));
            }

            var mangas = from m in _context.Manga
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                mangas = mangas.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(mangaGenre))
            {

                mangas = mangas.Where(x =>  x.Genre.Contains(mangaGenre));
            }

            var mangaGenreVM = new MangaGenreViewModel
            {
                Genres = new SelectList( genres.Distinct()),
                Mangas = await mangas.ToListAsync()
            };
            return View(mangaGenreVM);
        }

        // GET: Mangas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // GET: Mangas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mangas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,Illustrator,Description,RealeseDate,Genre")] Manga manga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manga);
        }

        // GET: Mangas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }
            return View(manga);
        }

        // POST: Mangas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,Illustrator,Description,RealeseDate,Genre")] Manga manga)
        {
            if (id != manga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangaExists(manga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manga);
        }

        // GET: Mangas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Manga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            return View(manga);
        }

        // POST: Mangas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manga = await _context.Manga.FindAsync(id);
            if (manga != null)
            {
                _context.Manga.Remove(manga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MangaExists(int id)
        {
            return _context.Manga.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Author()
        {
            return View();
        }
    }
}
