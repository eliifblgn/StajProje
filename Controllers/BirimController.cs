using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class BirimController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public BirimController(SecKaliteDbDbContext context)
        {
           _context = context;
        }

        //GET: Birim
        public async Task <IActionResult> Index()
        {
            return View(await _context.Birim.Where(b => !b.Silindi).ToListAsync());
        }

        //GET: Birim/Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birim = await _context.Birim
                .FirstOrDefaultAsync(m => m.Id == id && !m.Silindi);
            if (birim == null)
            {
                return NotFound();
            }
            return View(birim);
        }

        // GET: Birim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Birim/Create
        // To protect from overposting attacks, nabke the specific properties you want bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Birim birim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(birim);
        }

        //GET: Birim/Edit 
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birim = await _context.Birim.FindAsync(id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
        }


        // GET: Birim/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Birim birim)
        {
            if (id != birim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = await _context.Birim.FindAsync(id);
                if (guncellenecek == null)
                {
                    return NotFound();
                }

                guncellenecek.BirimAdi = birim.BirimAdi;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(birim);
        }

        // GET: Birim/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var silinecek = _context.Birim.Find(id);
            silinecek.Silindi = true;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BirimExists(long id)
        {
            return _context.Birim.Any(e => e.Id == id);
        }
    }
}
