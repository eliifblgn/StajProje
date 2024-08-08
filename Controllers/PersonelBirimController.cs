using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class PersonelBirimController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public PersonelBirimController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        //GET: PersonelBirim
        public async Task<IActionResult> Index()
        {
            return View(_context.PersonelBirim.Where(b => !b.Silindi).ToList());
        }

        //GET: PersonelBirim/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pbirim = _context.PersonelBirim
               .FirstOrDefault(m => m.Id == id && !m.Silindi);
            if (pbirim == null)
            {
                return NotFound();
            }

            return View(pbirim);
        }

        // GET: PersonelBirim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersinelBirim/Create
        // To protect from overposting attacks, nabke the specific properties you want bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonelBirim pbirim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pbirim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pbirim);
        }

        //GET: PersonelBirim/Edit 
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pbirim = await _context.PersonelBirim.FindAsync(id);
            if (pbirim == null)
            {
                return NotFound();
            }

            return View(pbirim);
        }


        //GET: PersonelBirim/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, PersonelBirim pbirim)
        {
            if (id != pbirim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var guncellenecek = await _context.PersonelBirim.FindAsync(id);
                if (guncellenecek == null)
                {
                    return NotFound();
                }

                guncellenecek.BirimAdi = pbirim.BirimAdi;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pbirim);
        }

        // GET: PersonelBirim/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var silinecek = _context.PersonelBirim.Find(id);
            silinecek.Silindi = true;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonelBirimExists(long id)
        {
            return _context.PersonelBirim.Any(e => e.Id == id);
        }
    }
}
