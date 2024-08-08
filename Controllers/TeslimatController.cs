using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecKaliteDb.Models;

namespace SecKaliteDb.Controllers
{
    [Authorize]
    public class TeslimatController : Controller
    {
        private readonly SecKaliteDbDbContext _context;

        public TeslimatController(SecKaliteDbDbContext context)
        {
            _context = context;
        }

        // GET: Teslimat
        public async Task<IActionResult> Index()
        {
            var teslimat = _context.Teslimat
                 .Include(p => p.Personel)
                 .Where(e => e.Silindi == false)
                 .ToList();
            return View(teslimat.ToList());
        }

        //// GET: Teslimat/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teslimat = await _context.Teslimat
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teslimat == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teslimat);
        //}

        // GET: Teslimat/Create
        public IActionResult Create()
        {
            var personelList = _context.Personel
               .Where(p => p.Silindi == false)
               .ToList();
            ViewData["PersonelId"] = new SelectList(personelList, "Id", "AdSoyad");
            //ViewBag.EnvanterDurumu = new SelectList(Enum.GetValues(typeof(EnvanterDurumu)).Cast<EnvanterDurumu>().Select(e => new { Id = e, Name = e.ToString() }), "Id", "Name");
            var envanterDurumuList = Enum.GetValues(typeof(EnvanterDurumu)).OfType<EnvanterDurumu>()
             .Select(e => new SelectListItem
             {
                 Value = ((int)e).ToString(),
                 Text = e.DisplayName()
             }).ToList();
            ViewData["EnvanterDurumu"] = new SelectList(envanterDurumuList, "Value", "Text");
            return View();
        }

        // POST: Teslimat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teslimat teslimat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teslimat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var personelList = _context.Personel
                 .Where(p => p.Silindi == false)
                 .ToList();
            ViewData["PersonelId"] = new SelectList(personelList, "Id", "AdSoyad");
            //ViewBag.EnvanterDurumu = new SelectList(Enum.GetValues(typeof(EnvanterDurumu)).Cast<EnvanterDurumu>().Select(e => new { Id = e, Name = e.ToString() }), "Id", "Name");
            var envanterDurumuList = Enum.GetValues(typeof(EnvanterDurumu)).OfType<EnvanterDurumu>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.DisplayName()
            }).ToList();

            ViewData["EnvanterDurumu"] = new SelectList(envanterDurumuList, "Value", "Text");
            return View(teslimat);
        }

        //// GET: Teslimat/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teslimat = await _context.Teslimat.FindAsync(id);
        //    if (teslimat == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(teslimat);
        //}

        //// POST: Teslimat/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind()] Teslimat teslimat)
        //{
        //    if (id != teslimat.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(teslimat);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TeslimatExists(teslimat.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(teslimat);
        //}

        //// GET: Teslimat/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var teslimat = await _context.Teslimat
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teslimat == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teslimat);
        //}

        //// POST: Teslimat/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var teslimat = await _context.Teslimat.FindAsync(id);
        //    if (teslimat != null)
        //    {
        //        teslimat.Silindi = true;
        //        _context.Teslimat.Update(teslimat);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TeslimatExists(long id)
        //{
        //    return _context.Teslimat.Any(e => e.Id == id);
        //}
    }
}
