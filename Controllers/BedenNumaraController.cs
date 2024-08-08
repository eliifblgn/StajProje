using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class BedenNumaraController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public BedenNumaraController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        //GET: BedenNumara
        public async Task<IActionResult> Index()
        {
            return View(await _context.BedenNumara.Where(b => !b.Silindi).ToListAsync());
        }

        //GET: BedenNumara/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bedennumara = await _context.BedenNumara
               .FirstOrDefaultAsync(m => m.Id == id && !m.Silindi);
            if (bedennumara == null)
            {
                return NotFound();
            }

            return View(bedennumara);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BedenNumara/Create
        // To protect from overposting attacks, nabke the specific properties you want bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BedenNumara bedennumara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedennumara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bedennumara);
        }

        //GET: BedenNumara/Edit 
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedennumara = await _context.BedenNumara.FindAsync(id);
            if (bedennumara == null)
            {
                return NotFound();
            }

            return View(bedennumara);
        }


        //GET: BedenNumara/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, BedenNumara bedennumara)
        {
            if (id != bedennumara.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = await _context.BedenNumara.FindAsync(id);
                if (guncellenecek == null)
                {
                    return NotFound();
                }

                guncellenecek.Beden = bedennumara.Beden;
                _context.BedenNumara.Update(guncellenecek);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(bedennumara);
        }

        // GET: BedenNumara/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silinecek = await _context.BedenNumara.FindAsync(id);
            if (silinecek == null)
            {
                return NotFound();
            }

            silinecek.Silindi = true;
            _context.BedenNumara.Update(silinecek);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        private bool BedenNumaraExists(long id)
        {
            return _context.BedenNumara.Any(e => e.Id == id);
        }
    }
}
