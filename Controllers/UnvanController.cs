using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class UnvanController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public UnvanController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        //GET: Unvan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unvan.Where(b => !b.Silindi).ToListAsync());
        }

        //GET: Unvan/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var unvan = await _context.Unvan
               .FirstOrDefaultAsync(m => m.Id == id && !m.Silindi);
            if (unvan == null)
            {
                return NotFound();
            }

            return View(unvan);
        }

        // GET: Unvan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unvan/Create
        // To protect from overposting attacks, nabke the specific properties you want bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Unvan unvan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unvan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(unvan);
        }

        //GET: Unvan/Edit 
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unvan = await _context.Unvan.FindAsync(id);
            if (unvan == null)
            {
                return NotFound();
            }

            return View(unvan);
        }


        //GET: Unvan/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Unvan unvan)
        {
            if (id != unvan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = await _context.Unvan.FindAsync(id);
                if (guncellenecek == null)
                {
                    return NotFound();
                }

                guncellenecek.UnvanAdi = unvan.UnvanAdi;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(unvan);
        }

        // GET: Unvan/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var silinecek = _context.Unvan.Find(id);
            silinecek.Silindi = true;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UnvanExists(long id)
        {
            return _context.Unvan.Any(e => e.Id == id);
        }
    }
}
