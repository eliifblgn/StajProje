using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class KkdNiteligiController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public KkdNiteligiController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: KkdNiteligi
        public async Task<IActionResult> Index()
        {
            var secKaliteDbDbContext = _context.KkdNiteligi
                .Include(p => p.KkdGrubu)
                .Where(p => !p.Silindi);
            return View(await secKaliteDbDbContext.ToListAsync());
        }

        // GET: KkdNiteligi/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kkdniteligi = await _context.KkdNiteligi
                .Include(p => p.KkdGrubu)
                .FirstOrDefaultAsync(m => m.Id == id && !m.Silindi);
            if (kkdniteligi == null)
            {
                return NotFound();
            }

            return View(kkdniteligi);
        }

        // GET: KkdNiteligi/Create
        public IActionResult Create()
        {
            ViewBag.KkdGrubuId = new SelectList(_context.KkdGrubu.Where(g => !g.Silindi), "Id", "KkdGrubuAdi");
            return View();
        }

        // POST: KkdNiteligi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KkdNiteligi kkdniteligi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kkdniteligi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KkdGrubuId = new SelectList(_context.KkdGrubu.Where(g => !g.Silindi), "Id", "KkdGrubuAdi", kkdniteligi.KkdGrubuId);
            return View(kkdniteligi);
        }


        // GET: KkdNiteligi/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kkdniteligi = await _context.KkdNiteligi
                .Include(k=> k.KkdGrubu)
                .FirstOrDefaultAsync(k=> k.Id == id);
            
            if (kkdniteligi == null)
            {
                return NotFound();
            }

            ViewBag.KkdGrubuId = new SelectList(_context.KkdGrubu.Where(g => !g.Silindi), "Id", "KkdGrubuAdi", kkdniteligi.KkdGrubuId);
            return View(kkdniteligi);
        }

        // POST: KkdNiteligi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,KkdNiteligi kkdniteligi)
        {
            if (id != kkdniteligi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kkdniteligi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KkdNiteligiExists(kkdniteligi.Id))
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

            ViewBag.KkdGrubuId = new SelectList(_context.KkdGrubu.Where(g => !g.Silindi), "Id", "KkdGrubuAdi", kkdniteligi.KkdGrubuId);
            return View(kkdniteligi);
        }

        // GET: KkdNiteligi/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silinecek = await _context.KkdNiteligi.FindAsync(id);
            if (silinecek == null)
            {
                return NotFound();
            }

            silinecek.Silindi = true;
            _context.KkdNiteligi.Update(silinecek);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool KkdNiteligiExists(long id)
        {
            return _context.KkdNiteligi.Any(e => e.Id == id);
        }
    }
}

